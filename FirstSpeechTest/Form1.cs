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

namespace FirstSpeechTest
{
    public partial class Form1 : Form
    {
        const string grammarConfigurationFile = "grammar.cfg";

        private SpeechRecognizer sr;
        private string[] commands = new string[2+2*4];
        private HttpListener webListen;
        private HttpServer webServer;
        private delegate void Del();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // much code from http://msdn.microsoft.com/en-us/library/hh361683(v=office.14).aspx

            /// Initialize the Speech Recognizer ///
            // Create a new SpeechRecognizer instance.
            sr = new SpeechRecognizer();

            // attempt to load any saved phrases
            tryToLoadGrammar();

            restartGrammar();

            /// Register for Speech Recognition Event Notification ///
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);


            /// start server
            /// http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx
            //webListen = new HttpListener();
            //webListen.Prefixes.Add("http://*:8080/");
            // start requires permissions: http://stackoverflow.com/a/4115328
            //webListen.Start();
            // get context (blocking)
            // request
            // response


            webServer = new HttpServer();
            if( webServer.Start("http://*:8080/") ){
                delReceiveWebRequest handleWebRequest_delegate = handleWebRequest;
                webServer.ReceiveWebRequest += new Westwind.InternetTools.delReceiveWebRequest(handleWebRequest_delegate);
            }else{
                writeLog("Server could not be started, do you have admin privs?");
                writeLog("You could try http://stackoverflow.com/a/4115328 so as to not need them all the time");
            }
            
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

            writeLog("(" + commandIndex + ") " + speechEvent.Result.Text);

            switch (commandIndex)
            {
                case 0:
                    // on
                    // one string for a faster command
                    writeToPort(
                        "D:01:255\n" +
                        "D:02:255\n" +
                        "D:03:255\n" +
                        "D:04:255\n"
                    );
                    break;
                case 1:
                    // off
                    // one string for a faster command
                    writeToPort(
                        "D:01:0\n" +
                        "D:02:0\n" +
                        "D:03:0\n" +
                        "D:04:0\n"
                    );
                    break;
                case 2:
                    // on
                    writeToPort("D:01:255\n");
                    break;
                case 3:
                    // off
                    writeToPort("D:01:0\n");
                    break;
                case 4:
                    // on
                    writeToPort("D:02:255\n");
                    break;
                case 5:
                    // off
                    writeToPort("D:02:0\n");
                    break;
                case 6:
                    // on
                    writeToPort("D:03:255\n");
                    break;
                case 7:
                    // off
                    writeToPort("D:03:0\n");
                    break;
                case 8:
                    // on
                    writeToPort("D:04:255\n");
                    break;
                case 9:
                    // off
                    writeToPort("D:04:0\n");
                    break;
                default:
                    break;
            }

        }

        private void writeLog(string lineToAdd)
        {
            Console.WriteLine(lineToAdd);
            tb_log.Text += lineToAdd + Environment.NewLine;
            tb_log.SelectionStart = tb_log.Text.Length;
            tb_log.ScrollToCaret();
        }

        private void writeLog_threadsafe(string lineToAdd)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.writeLog(lineToAdd);
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


            //throw new NotImplementedException();
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
            sp_fusionBrain6.PortName = "COM" + nud_com_number.Value;
        }

        private bool writeToPort( String toSend ){
            try{
                sp_fusionBrain6.Open();
                sp_fusionBrain6.Write( toSend );
                sp_fusionBrain6.Close();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                writeLog("Error in COM port communication, on "+sp_fusionBrain6.PortName);
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
                // faster creation
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
            this.Invoke((MethodInvoker)delegate
            {
                this.writeLog("Cross thread call!");
            });

            writeLog_threadsafe("handleWebRequest called!");
            HttpListenerRequest Request = Context.Request;
            HttpListenerResponse Response = Context.Response;
            //writeLog("can we write during a delegate?"); // YES!! but not when debugging...writeLog_threadsafe!!
            //writeLog_threadsafe(Request.HttpMethod + " " + Request.RawUrl + " Http/" + Request.ProtocolVersion.ToString());
            writeLog_threadsafe("HttpMethod: " + Request.HttpMethod);
            writeLog_threadsafe("RawUrl: " + Request.RawUrl);
            writeLog_threadsafe("Protocol Version: " + Request.ProtocolVersion.ToString());

            // http://www.west-wind.com/weblog/posts/2005/Dec/04/Add-a-Web-Server-to-your-NET-20-app-with-a-few-lines-of-code
            string Output = "<html><body><h1>Hello world</h1>Time is: " + DateTime.Now.ToString() + "<pre>" + "stuff" + "</pre>";

            byte[] bOutput = System.Text.Encoding.UTF8.GetBytes(Output);

            Response.ContentType = "text/html";
            Response.ContentLength64 = bOutput.Length;

            Stream OutputStream = Response.OutputStream;
            OutputStream.Write(bOutput, 0, bOutput.Length);
            OutputStream.Close();
        }
    }
}
