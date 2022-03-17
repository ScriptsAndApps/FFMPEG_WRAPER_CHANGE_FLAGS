using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text;
namespace ProgramProgram
{
    class Program
    {
		public static string inifilename = "ffmpeg_arguments_hack.ini";
		public static string logContents = "";
		public static string fileName = @"ffmpeg_original.exe";
		public static string log_file_name = @"log.txt";
		public static string folder = @"ffmpeg_hack_logs";
		public static string argument_time_ = "-t";
		public static string argument_new_time_value = "1500000";
		
		public static string argument_1 = "-not_set";
		public static string argument_1_new_value = "novalue1";
		
		public static string argument_2 = "-not_set";
		public static string argument_2_new_value = "novalue2";
		
		public static string argument_3 = "-not_set";
		public static string argument_3_new_value = "novalue3";
		
		public static string argument_4 = "-not_set";
		public static string argument_4_new_value = "novalue4";
		
		public static string argument_5 = "-not_set";
		public static string argument_5_new_value = "novalue5";

		public static string ADD_ARGUMENTS_HERE = "-vol 256 -loglevel repeat+level+verbose";

		public static bool createlogs = true;
		
		[MTAThread]
        public static void Main(string[] args)
        {
			inistore storage = new inistore();

			fileName = storage.get("original_ffmpeg_file",fileName);
			storage.set("PLASE_RENAME_THE_ORIGINAL_ffmpeg.exe_TO_",">> "+fileName+ " <<");
			storage.set("THEN_THIS_HACK_FILE_SHOULD_BE_CALLED_FFMPEG.EXE_AND_BE_PLACED_IN_THE_FOLDER","IF_IM_NOT_RENAME_ME_TO: FFMPEG.EXE << verry important");
			
			createlogs = storage.get("createlogs",createlogs);
			folder = storage.get("logfilefolder_name",folder);
			log_file_name = storage.get("logfilename",log_file_name);
			
			storage.get("_time____________________","");
		    argument_time_ = storage.get("arg_time",argument_time_);
			argument_new_time_value = storage.get("replace_max_time_length_value",argument_new_time_value);
			
			storage.get("_____optional____________","");
			argument_1 = storage.get("arg_opt1",argument_1);
			argument_1_new_value = storage.get("replaceopt1__value",argument_1_new_value);
			
			storage.get("____optional_____________","");
			argument_2 = storage.get("arg_opt2",argument_1);
			argument_2_new_value = storage.get("replaceopt2_value",argument_2_new_value);
			
			storage.get("___optional______________","");
			argument_3 = storage.get("arg_opt3",argument_1);
			argument_3_new_value = storage.get("replaceopt3_value",argument_3_new_value);
			
			storage.get("__optional_______________","");
			argument_4 = storage.get("arg_opt4",argument_1);
			argument_4_new_value = storage.get("replaceopt4_value",argument_4_new_value);
	
			storage.get("_optional________________","");
			argument_5 = storage.get("arg_opt5",argument_1);
			argument_5_new_value = storage.get("replaceopt5_value",argument_5_new_value);
			
			storage.get("optional_________________","");
			ADD_ARGUMENTS_HERE = storage.get("ADD_ARGUMENTS_HERE",ADD_ARGUMENTS_HERE);
			
			
			string path = folder +"\\"+ log_file_name;
			int filenumber = 0;
			bool getnewpath = true;
			while(getnewpath)
			{	
				filenumber++;
				path = folder +"\\"+ log_file_name.Replace(".txt",filenumber + ".txt");
				getnewpath = File.Exists(path);
			}
			StreamWriter sw = null;
			if(createlogs){

			    if (!System.IO.File.Exists(folder +"\\"))
			    {
					Directory.CreateDirectory(folder +"\\");
				}
			}
			
			if(createlogs){ sw = File.CreateText(path); }
			
			string arglist = "";
			foreach (Object obj in args)  
			{  	
				arglist += obj.ToString()+" ";							
			} 
			if(!File.Exists(fileName))
			{
				if(sw==null) sw = File.CreateText("error.txt"); 
				sw.WriteLine("Can not find " +  fileName);
				sw.Close();
		
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("");
				Console.WriteLine("      >>>   Can not find " + fileName + "   <<<  Please rename ffmpeg.exe to " + fileName + "  !!! ");
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("");
				Console.WriteLine("      >>>   Can not find " + fileName + "   <<<  Please rename ffmpeg.exe to " + fileName + "  !!! ");
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("");
				Console.WriteLine("      >>>  Rename me to FFMPEG.EXE and read " + inifilename + "  <<<     ");
				Console.WriteLine("");
				bool switchcolor = true;				
				for(int i = 35; i > 0; --i)
				{
					Console.SetCursorPosition(0,1);
					if(switchcolor)
					{	switchcolor=!switchcolor;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
					}else{
						switchcolor=!switchcolor;
						Console.BackgroundColor = ConsoleColor.White;
						Console.ForegroundColor = ConsoleColor.Red;
					}
					Console.WriteLine("      >>>   Can not find " + fileName + "   <<<  Please rename ffmpeg.exe to " + fileName + "  !!! ");
					Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop+5);	
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.Green;	
					Console.Write("\r      >>>   Closing in {0}  <<<      ", i);
					Thread.Sleep(1000);
				}
				
				return;
			}
			if(createlogs){	
				sw.WriteLine("Original argument list -->");		
				sw.WriteLine(arglist);		
				sw.WriteLine("<-- Original argument list");	
			}					
			
			ProcessStartInfo pii = new ProcessStartInfo{
				UseShellExecute = false,
				RedirectStandardError = true,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				FileName = fileName
			};
			
			string arglistout = "";
			string lastarg = "";
			foreach (Object obj in args)  
			{
				string temparg = obj.ToString();  

				//edit args or delete them here
				if(lastarg == argument_time_){	
					temparg = argument_new_time_value;	
				}
				if(lastarg == argument_1){	
					temparg = argument_1_new_value;	
				}
				if(lastarg == argument_2){	
					temparg = argument_2_new_value;	
				}
				if(lastarg == argument_3){	
					temparg = argument_3_new_value;	
				}
				if(lastarg == argument_4){	
					temparg = argument_4_new_value;	
				}
				if(lastarg == argument_5){	
					temparg = argument_5_new_value;	
				}
				
				//Be sure the arguments with spaces are nor read as seperate arguments
				if(temparg.Contains(" ")){ temparg= "\""+temparg+"\""; }
				//finally add the args to the args list 
				//adding a space for each new arg
				arglistout += temparg + " ";
				lastarg = obj.ToString();
			} 
			//set new altered arguments + add new arguments
			pii.Arguments = arglistout + ADD_ARGUMENTS_HERE;
			if(createlogs){	
				sw.WriteLine("Altered argument list -->");		
				sw.WriteLine(arglistout + ADD_ARGUMENTS_HERE);			
				sw.WriteLine("<-- Altered  argument list");		
			}
			// Fires up a new process to run inside this one
			var process = Process.Start(pii);
			// Depending on your application you may either prioritize the IO or the exact opposite
			const ThreadPriority ioPriority = ThreadPriority.Highest;
			var outputThread = new Thread(outputReader) { Name = "ChildIO Output", Priority = ioPriority};
			var errorThread = new Thread(errorReader) { Name = "ChildIO Error", Priority = ioPriority };
			var inputThread = new Thread(inputReader) { Name = "ChildIO Input", Priority = ioPriority };
			// Set as background threads (will automatically stop when application ends)
			outputThread.IsBackground = errorThread.IsBackground = inputThread.IsBackground = true;
			// Start the IO threads
			outputThread.Start(process);
			errorThread.Start(process);
			inputThread.Start(process);
			//process.StandardInput.WriteLine("Message from host");
			// Signal to end the application
			ManualResetEvent stopApp = new ManualResetEvent(false);
			// Enables the exited event and set the stopApp signal on exited
			process.EnableRaisingEvents = true;
			process.Exited += (e, sender) => { stopApp.Set(); };
			// Wait for the child app to stop
			stopApp.WaitOne();
			
			//Add to logfile the output of ffmpeg
			if(createlogs){
				sw.WriteLine(logContents);
				sw.Close();
			}					
			
			//for visual output and more
            Thread.Sleep(300);
            //Thread.Sleep(3000);
        }

        /// <summary>
        /// Continuously copies data from one stream to the other.
        /// </summary>
        /// <param name="instream">The input stream.</param>
        /// <param name="outstream">The output stream.</param>
        private static void passThrough(Stream instream, Stream outstream)
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                int len;
                while ((len = instream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outstream.Write(buffer, 0, len);
					//add crude logger of the output of the console 
					logContents += System.Text.Encoding.Default.GetString(buffer);
                    outstream.Flush();
                }
            }
        }

        private static void outputReader(object p)
        {
            var process = (Process)p;
            // Pass the standard output of the child to our standard output
            passThrough(process.StandardOutput.BaseStream, Console.OpenStandardOutput());
        }

        private static void errorReader(object p)
        {
            var process = (Process)p;
            // Pass the standard error of the child to our standard error
            passThrough(process.StandardError.BaseStream, Console.OpenStandardError());
        }

        private static void inputReader(object p)
        {
            var process = (Process)p;
            // Pass our standard input into the standard input of the child
            passThrough(Console.OpenStandardInput(), process.StandardInput.BaseStream);
        }
		
		
		public class inistore{
			
				string Path;
				string EXE = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
				
				public inistore()
				{  
					Initialize(inifilename);
					  
				}
				
				public void Initialize(string IniPath = null)
				{
					Path = new System.IO.FileInfo(IniPath ?? EXE + ".ini").FullName;
				}
				
				public string get(string key, string s)
				{
					try {
						if (KeyExists(key))
						{
							string t = Read(key);
							if (t != "")
								s = t;
						}
					} catch { }
					set(key, s);
					return s;
				}
				
				public bool get(string key, bool b)
				{
					if (KeyExists(key))
					{
						try { b = bool.Parse(Read(key)); } catch { }
					}
					set(key,b);
					return b;
				}
				public float get(string key, float f)
				{
					if (KeyExists(key))
					{
						try { f = float.Parse(Read(key)); } catch { }
					}
					set(key, f);
					return f;
				}
				public int get(string key, int i)
				{
					if (KeyExists(key))
					{
						try { i = int.Parse(Read(key)); }catch { }
					}
					set(key, i);
					return i;
				}
				public long get(string key, long l)
				{
					if (KeyExists(key))
					{
						try { l = long.Parse(Read(key)); } catch { }
					}
					set(key, l);
					return l;
				}
				public double get(string key, double d)
				{
					if (KeyExists(key))
					{
						try { d = double.Parse(Read(key)); } catch { }
					}
					set(key, d);
					return d;
				}
				public void set(string key, string value)
				{
					try { Write(key, value.ToString()); } catch { }
				}
				public void set(string key, bool value)
				{
					try { Write(key, value.ToString()); } catch { }
				}
				public void set(string key, float value)
				{
					try { Write(key, value.ToString("0.00")); } catch { }
				}
				public void set(string key, int value)
				{
					try { Write(key, value.ToString()); } catch { }
				}
				public void set(string key, long value)
				{
					try { Write(key, value.ToString()); } catch { }
				}
				public void set(string key, double value)
				{
					try { Write(key, string.Format("{0:N2}", value)); } catch { }
				}
				[System.Runtime.InteropServices.DllImport("kernel32", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
				static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

				[System.Runtime.InteropServices.DllImport("kernel32", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
				static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

				public string Read(string Key, string Section = null)
				{
					var RetVal = new StringBuilder(255);
					GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
					return RetVal.ToString();
				}

				public void Write(string Key, string Value, string Section = null)
				{
					WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
				}

				public bool KeyExists(string Key, string Section = null)
				{
					return Read(Key, Section).Length > 0;
				}

				/*public void DeleteKey(string Key, string Section = null)
				{
					Write(Key, null, Section ?? EXE);
				}

				public void DeleteSection(string Section = null)
				{
					Write(null, null, Section ?? EXE);
				}*/

	

		}
		
    }
}
