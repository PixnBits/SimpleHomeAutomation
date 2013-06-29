using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.IO;
using System.Net;
using Westwind.InternetTools;
using System.Speech.Synthesis;

namespace FirstSpeechTest
{
    public partial class Form1 : Form
    {
        const string grammarConfigurationFile = "grammar.cfg";
        const string FUSIONBRAIN6_DIGITAL = "D:{0:D2}:{1:D}\n";

        private NotifyIcon noteIcon;
        private SpeechRecognizer sr;
        private string[] commands = new string[2+2*4];
        private HttpServer webServer;
        private delegate void Del();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            createNotifyIcon();

            // much speech code from http://msdn.microsoft.com/en-us/library/hh361683(v=office.14).aspx

            /// Initialize the Speech Recognizer ///
            // Create a new SpeechRecognizer instance.
            sr = new SpeechRecognizer();

            // attempt to load any saved phrases
            tryToLoadGrammar();

            restartGrammar();

            /// Register for Speech Recognition Event Notification ///
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);

            webServer = new HttpServer();
            if( webServer.Start("http://*:8080/") ){
                delReceiveWebRequest handleWebRequest_delegate = handleWebRequest;
                webServer.ReceiveWebRequest += new Westwind.InternetTools.delReceiveWebRequest(handleWebRequest_delegate);
            }else{
                writeLog("Server could not be started, do you have admin privs?", true);
                writeLog("You could try http://stackoverflow.com/a/4115328 so as to not need them all the time");
            }
            
        }

        private void createNotifyIcon()
        {
            noteIcon = new NotifyIcon();
            noteIcon.Text = this.Text;
            noteIcon.BalloonTipTitle = this.Text;
            noteIcon.BalloonTipText = "Simple Home Automation running in the background, click to restore.";
            noteIcon.MouseClick += new MouseEventHandler(noteIcon_MouseClick);
            try
            {
                // http://stackoverflow.com/a/90699
                noteIcon.Icon = Properties.Resources.preferences_desktop;
            }catch(Exception e){
                writeLog("Unable to add icon to NotifyIcon: "+ e.Message);
                Console.WriteLine(e);
            }
        }

        void noteIcon_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            noteIcon.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save commands for next time
            System.IO.File.WriteAllLines(grammarConfigurationFile, commands);
            //webListen.Stop();
            webServer.Stop();
        }

        /// Create a Speech Recognition Event Handler ///
        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs speechEvent)
        {
            
            int commandIndex = -1;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].Equals(speechEvent.Result.Text))
                {
                    commandIndex = i;
                    break;
                }
            }

            writeLog("(" + commandIndex + ") " + speechEvent.Result.Text, true);

            // could skip switch for
            //writeLog((int)(commandIndex / 2) + " " + (commandIndex % 2));
            // but *very* future blind

            switch (commandIndex)
            {
                case 0:
                    // on
                    controlChannel(int.MaxValue, 1);
                    break;
                case 1:
                    // off
                    controlChannel(int.MaxValue, 0);
                    break;
                case 2:
                    // on
                    controlChannel(1, 1);
                    break;
                case 3:
                    // off
                    controlChannel(1, 0);
                    break;
                case 4:
                    // on
                    controlChannel(2, 1);
                    break;
                case 5:
                    // off
                    controlChannel(2, 0);
                    break;
                case 6:
                    // on
                    controlChannel(3, 1);
                    break;
                case 7:
                    // off
                    controlChannel(3, 0);
                    break;
                case 8:
                    // on
                    controlChannel(4, 1);
                    break;
                case 9:
                    // off
                    controlChannel(4, 0);
                    break;
                default:
                    writeLog("unknown voice command: " + speechEvent.Result.Text, true);
                    break;
            }

        }

        public bool controlChannel(int index, float percentageDimmed)
        {
            if ((index < 0) || ((index > 31)&&(index!=int.MaxValue)) )
                return false;
            if (percentageDimmed < 0)
                percentageDimmed = -1 * percentageDimmed;
            if (percentageDimmed > 1)
                percentageDimmed = 1;
            int channelValue = (int)(255 * percentageDimmed);

            if (index == int.MaxValue)
            {
                // one string for a faster command
                string allPorts = "";

                int maxChannel = 31;

                // all 30+ LED's are too much for USB to power
                // ...or I hurt my FB6 by running relays without a diode protector :'(
                // hardware failure when turning *all* all on
                if (percentageDimmed > 0)
                    maxChannel = 5;

                for (int i = 1; i < maxChannel; i++)
                {
                    allPorts += String.Format(FUSIONBRAIN6_DIGITAL, i, channelValue);
                }
                return writeToPort(allPorts);
            }
            else
            {
                return writeToPort(String.Format(FUSIONBRAIN6_DIGITAL, index, channelValue));
            }
        }

        private void writeLog(string lineToAdd, bool alsoSpeak = false)
        {
            Console.WriteLine(lineToAdd);
            tb_log.Text += lineToAdd + Environment.NewLine;
            tb_log.SelectionStart = tb_log.Text.Length;
            tb_log.ScrollToCaret();

            if(alsoSpeak)
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                Prompt sayThis = new Prompt(lineToAdd);
                synth.Speak(sayThis);
            }
        }

        private void writeLog_threadsafe(string lineToAdd, bool alsoSpeak = false)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.writeLog(lineToAdd, alsoSpeak);
            });
        }

        void restartGrammar()
        {
            /// Create a Speech Recognition Grammar ///
            //Choices colors = new Choices();
            //colors.Add(new string[] { "red", "green", "blue" });
            Choices choice_commands = new Choices();
            loadCommandsFromTextBoxes();

            choice_commands.Add(commands);

            GrammarBuilder gb = new GrammarBuilder();
            //gb.Append(colors);
            gb.Append(choice_commands);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);

            /// Load the Grammar into the Speech Recognizer ///
            sr.LoadGrammar(g);
        }

        private void loadCommandsFromTextBoxes()
        {
            commands[0] = txb_all_on.Text;
            commands[1] = txb_all_off.Text;

            commands[2] = txb_ch1_on.Text;
            commands[3] = txb_ch1_off.Text;
            commands[4] = txb_ch2_on.Text;
            commands[5] = txb_ch2_off.Text;
            commands[6] = txb_ch3_on.Text;
            commands[7] = txb_ch3_off.Text;
            commands[8] = txb_ch4_on.Text;
            commands[9] = txb_ch4_off.Text;
        }

        private void loadTextBoxesFromCommands()
        {
            txb_all_on.Text  = commands[0];
            txb_all_off.Text = commands[1];

            txb_ch1_on.Text  = commands[2];
            txb_ch1_off.Text = commands[3];
            txb_ch2_on.Text  = commands[4];
            txb_ch2_off.Text = commands[5];
            txb_ch3_on.Text  = commands[6];
            txb_ch3_off.Text = commands[7];
            txb_ch4_on.Text  = commands[8];
            txb_ch4_off.Text = commands[9];
        }

        private void nud_com_number_ValueChanged(object sender, EventArgs e)
        {
            //TODO smart detect available ports
            sp_fusionBrain6.PortName = "COM" + nud_com_number.Value;
        }

        private bool writeToPort( String toSend ){
            try{
                sp_fusionBrain6.Open();
                sp_fusionBrain6.Write( toSend );
                sp_fusionBrain6.Close();
                writeLog_threadsafe("sent command " + toSend);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                writeLog_threadsafe("Error in COM port communication, on " + sp_fusionBrain6.PortName, true);
            }
            return false;
        }

        private void tryToLoadGrammar()
        {
            if (System.IO.File.Exists(grammarConfigurationFile))
            {
                commands = System.IO.File.ReadAllLines(grammarConfigurationFile);
                loadTextBoxesFromCommands();
            }
            else
            {
                // faster creation?
                FileStream grammarFile = System.IO.File.Create(grammarConfigurationFile);
                grammarFile.Close();

                loadCommandsFromTextBoxes();
                System.IO.File.WriteAllLines(grammarConfigurationFile, commands);
            }
        }

        private void btn_grammarChange_Click(object sender, EventArgs e)
        {
            restartGrammar();
        }

        private void handleWebRequest(HttpListenerContext Context)
        {

            //writeLog_threadsafe("handleWebRequest called!");
            HttpListenerRequest Request = Context.Request;
            HttpListenerResponse Response = Context.Response;
            //writeLog("can we write during a delegate?"); // YES!! but not when debugging...writeLog_threadsafe!!
            //writeLog_threadsafe(Request.HttpMethod + " " + Request.RawUrl + " Http/" + Request.ProtocolVersion.ToString());
            //writeLog_threadsafe("HttpMethod: " + Request.HttpMethod);
            //writeLog_threadsafe("RawUrl: " + Request.RawUrl);
            //writeLog_threadsafe("Protocol Version: " + Request.ProtocolVersion.ToString());

            string[] requestPath = Request.RawUrl.Substring(1).Split('/');

            /*
            for (int i = 0; i < requestPath.Length; i++)
            {
                writeLog_threadsafe("path " + i + " is " + requestPath[i]);
            }//*/
            int channel;
            
            string responseString;


            // default response (unhandled)
            responseString = "<html><body><h1>Hello world</h1>Time is: " + DateTime.Now.ToString() + "</body></html>";

            /// url forms:
            /// example.com/api/channels/1/on     on all the way (dimming % is 100%)
            /// example.com/api/channels/3/on/50  for dimming (% of full)

            if (requestPath.Length > 0)
            {
                switch (requestPath[0])
                {
                    case "api":
                        if (requestPath.Length < 2)
                            break;
                        switch (requestPath[1])
                        {
                            case "channels":
                                if (requestPath.Length < 3)
                                    break;
                                //TODO check for "all" instead of number
                                if( "all".Equals(requestPath[2]) ){
                                    channel = int.MaxValue;
                                }else{
                                    try{
                                        channel = int.Parse(requestPath[2]);
                                    }catch(Exception e){
                                        // TODO handle incorrect channel
                                        break;
                                    }
                                }

                                if (requestPath.Length < 4)
                                    break;
                                switch (requestPath[3])
                                {
                                    case "on":
                                        writeLog_threadsafe("API request to turn " + channel + " on", true);
                                        if (controlChannel(channel, 1))
                                        {
                                            responseString = "<html><body>Correct API endpoint, channel " + channel + " and command successful</body></html>";
                                        }
                                        else
                                        {
                                            responseString = "<html><body>Correct API endpoint, channel " + channel + " but error in execution of command :(</body></html>";
                                        }
                                        break;
                                    case "off":
                                        writeLog_threadsafe("API request to turn " + channel + " off", true);
                                        if (controlChannel(channel, 0))
                                        {
                                            responseString = "<html><body>Correct API endpoint, channel " + channel + " and command successful</body></html>";
                                        }
                                        else
                                        {
                                            responseString = "<html><body>Correct API endpoint, channel " + channel + " but error in execution of command :(</body></html>";
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }


            // http://www.west-wind.com/weblog/posts/2005/Dec/04/Add-a-Web-Server-to-your-NET-20-app-with-a-few-lines-of-code
            byte[] bOutput = System.Text.Encoding.UTF8.GetBytes(responseString);

            Response.ContentType = "text/html";
            Response.ContentLength64 = bOutput.Length;

            Stream OutputStream = Response.OutputStream;
            OutputStream.Write(bOutput, 0, bOutput.Length);
            OutputStream.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                noteIcon.Visible = true;
                noteIcon.ShowBalloonTip(2000);
                this.ShowInTaskbar = false;
            }
        }
    }
}
