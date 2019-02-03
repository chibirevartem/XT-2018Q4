using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Epam.Task06.BackUpSystem_WF
{
    public class BackUpSystem
    {
        private readonly System.IO.FileSystemWatcher filewatcher;
        private StreamWriter logger = null;
        private readonly string tracking_directory;
        private readonly string backup_directory;
        private readonly string logger_fullpath;
        private readonly string filter;
        private int files_count = 0;

        public BackUpSystem(string tracking_directory, string backup_directory, string filter, bool IsTracking)
        {
            this.tracking_directory = tracking_directory;
            this.backup_directory = backup_directory;
            this.filter = filter;
            logger_fullpath = Path.Combine(backup_directory, "logger.txt");
            if (!Directory.Exists(backup_directory) || !File.Exists(logger_fullpath))
            {
                Directory.CreateDirectory(backup_directory);
                string[] files_in_backup = Directory.GetFiles(backup_directory);
                foreach (var file in files_in_backup)
                {
                    File.Delete(file);
                }
                (File.Create(logger_fullpath)).Close();

                string[] all_tracking_files = Directory.GetFiles(tracking_directory, "*" + filter, SearchOption.AllDirectories);
                Save("Created", all_tracking_files);
            }
            else
            {
                var c = Directory.GetFiles(this.backup_directory, "BackUp*" + filter, SearchOption.AllDirectories);
                files_count = c.Length;
            }

            filewatcher = new FileSystemWatcher(tracking_directory);
            filewatcher.IncludeSubdirectories = true;
            filewatcher.Changed += FileSystemWatcher_OnChanged;
            filewatcher.Created += FileSystemWatcher_OnCreated;
            filewatcher.Deleted += FileSystemWatcher_OnCreated;
            filewatcher.Renamed += FileSystemWatcher_OnRenamed;
            filewatcher.Error += FileSystemWatcher_OnError;
            filewatcher.EnableRaisingEvents = IsTracking;
        }

        void Recovery(StreamReader reader, string action)
        {
            string restoring_file;
            string renamed_file;
            string backup_file;
            string deleted_file;
            switch (action)
            {
                case "Created":
                    {
                        restoring_file = reader.ReadLine();
                        backup_file = reader.ReadLine();
                        Directory.CreateDirectory(Path.GetDirectoryName(restoring_file));
                        File.Copy(backup_file, restoring_file, true);
                        break;
                    }
                case "Changed":
                    {
                        restoring_file = reader.ReadLine();
                        backup_file = reader.ReadLine();
                        Directory.CreateDirectory(Path.GetDirectoryName(restoring_file));
                        File.Copy(backup_file, restoring_file, true);
                        break;
                    }
                case "Deleted":
                    {
                        deleted_file = reader.ReadLine();
                        File.Delete(reader.ReadLine());
                        break;
                    }
                case "Renamed":
                    {
                        restoring_file = reader.ReadLine();
                        renamed_file = reader.ReadLine();
                        File.Move(renamed_file, restoring_file);
                        break;
                    }
                default: break;
            }


        }
        public void RestoreTo(DateTime restoration_time)
        {
            if (filewatcher.EnableRaisingEvents == true) { return; }
            StreamReader logger_reader = null;
            DateTime current_logger_time;
            string[] all_files = Directory.GetFiles(tracking_directory, "*" + filter, SearchOption.AllDirectories);
            foreach (var file in all_files)
            {
                File.Delete(file);
            }
            using (logger_reader = new StreamReader(logger_fullpath))
            {
                bool result = DateTime.TryParse(logger_reader.ReadLine(), out current_logger_time);
                if (!result) { throw new Exception("Parsing Error"); }
                if (restoration_time < current_logger_time)
                {
                    restoration_time = current_logger_time;
                }

                while (restoration_time >= current_logger_time)
                {
                    string action = logger_reader.ReadLine();
                    Recovery(logger_reader, action);
                    if (logger_reader.Peek() < 0) { break; }
                    current_logger_time = DateTime.Parse(logger_reader.ReadLine());
                } 
                Console.WriteLine("Restoring has been done");
            }


        }
        private void Save(string file_event, params string[] tracking_files_fullpath)
        {
            using (logger = new StreamWriter(logger_fullpath, true))
            {
                var time = DateTime.Now.ToString();
                foreach (var tracking_file_fullpath in tracking_files_fullpath)
                {
                    string backup_filename = Path.Combine(backup_directory, "BackUp" + files_count.ToString() + ".txt");
                    string backup_file_fullpath = Path.Combine(backup_directory, backup_filename);
                    File.Copy(tracking_file_fullpath, backup_file_fullpath);

                    logger.WriteLine(time);
                    logger.WriteLine(file_event);
                    logger.WriteLine(tracking_file_fullpath);
                    logger.WriteLine(backup_file_fullpath);

                    files_count++;
                }
            }
            logger.Close();
        }
        private void FileSystemWatcher_OnCreated(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter) return;
            Console.WriteLine($"File:{e.FullPath} has been created");
            var tracking_file_fullpath = e.FullPath;
            Save("Created", tracking_file_fullpath);
        }
        private void FileSystemWatcher_OnRenamed(object sender, RenamedEventArgs e)
        {
            var fileInfo = new FileInfo(e.OldFullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter) return;
            Console.WriteLine($"File:{e.OldFullPath} has been renamed to {e.FullPath}");
            var time = DateTime.Now.ToString();
            using (logger = new StreamWriter(logger_fullpath, true))
            {
                logger.WriteLine(time);
                logger.WriteLine("Renamed");
                logger.WriteLine(e.FullPath);
                logger.WriteLine(e.OldFullPath);
            }
            logger.Close();
        }
        private void FileSystemWatcher_OnChanged(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter) return;
            Console.WriteLine($"File:{e.FullPath} has been changed");
            Save("Changed", e.FullPath);
        }
        private void FileSystemWatcher_OnDeleted(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter) return;
            Console.WriteLine($"File: {e.FullPath} deleted");

            using (logger = new StreamWriter(logger_fullpath, true))
            {
                logger.WriteLine(DateTime.Now.ToString());
                logger.WriteLine("Deleted");
                logger.WriteLine(e.FullPath);
            }
            logger.Close();

        }
        private void FileSystemWatcher_OnError(object source, ErrorEventArgs e)
        {
            Console.WriteLine("The FileSystemWatcher has detected an error");

            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }
    }
}
