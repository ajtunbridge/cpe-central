#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryNameGenerator.Data;
using InventoryNameGenerator.Modules;
using InventoryNameGenerator.Properties;

#endregion

namespace InventoryNameGenerator
{
    public class MainFormPresenter
    {
        private readonly MainForm _mainForm;

        public MainFormPresenter(MainForm mainForm)
        {
            _mainForm = mainForm;

            _mainForm.LoadModules += MainForm_LoadModules;
            _mainForm.ModuleSelected += MainForm_ModuleSelected;
            _mainForm.EditModuleDataFile += _mainForm_EditModuleDataFile;
        }

        void _mainForm_EditModuleDataFile(object sender, IModuleEventArgs e)
        {
            var dataEditor = new DataEditorDialog(e.Module);

            if (dataEditor.ShowDialog(_mainForm) != DialogResult.OK) {
                return;
            }

            e.Module.SaveDataFile(Settings.Default.ModuleDataDir);

            MainForm_ModuleSelected(sender, e);
        }

        private void MainForm_ModuleSelected(object sender, IModuleEventArgs e)
        {
            Task.Factory.StartNew(() => {
                e.Module.LoadDataFile(Settings.Default.ModuleDataDir);

                var panel = e.Module.CreatePanel();

                _mainForm.Invoke((MethodInvoker) (() => _mainForm.DisplaySelectedModule(panel)));
            });
        }

        private void MainForm_LoadModules(object sender, EventArgs e)
        {
            var loadModulesWorker = new BackgroundWorker();
            loadModulesWorker.DoWork += loadModulesWorker_DoWork;
            loadModulesWorker.RunWorkerCompleted += loadModulesWorker_RunWorkerCompleted;
            loadModulesWorker.RunWorkerAsync();
        }

        private void loadModulesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var loadedModules = e.Result as List<IModule>;

            _mainForm.DisplayModules(loadedModules);
        }

        private void loadModulesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Directory.Exists(Settings.Default.ModuleUpdateDir)) {
                _mainForm.UpdateStatus("checking for new and updated modules....");

                CheckForNewAndUpdatedModules();

                _mainForm.UpdateStatus("a little bit of housekeeping....");

                RemoveOrphanedLocalModules();

                GenerateMissingDataFiles();
            }

            _mainForm.UpdateStatus("loading modules....");

            var modules = LoadModules();

            e.Result = modules;
        }

        /// <summary>
        ///     Copies locally any new or modified modules from the remote update directory
        /// </summary>
        /// <returns></returns>
        private void CheckForNewAndUpdatedModules()
        {
            var remoteModulePath = Settings.Default.ModuleUpdateDir;

            if (!Directory.Exists(remoteModulePath)) {
                throw new DirectoryNotFoundException("Unable to find the update directory!");
            }

            var remoteModules = Directory.GetFiles(remoteModulePath, "Module.*.dll");
            var localModules = Directory.GetFiles(Session.LocalModuleDir, "Module.*.dll");

            var modulesToDownload = new List<string>();

            foreach (var remoteModule in remoteModules) {
                var filename = Path.GetFileName(remoteModule);

                // if module exists, check if it's up to date
                if (localModules.Any(x => Path.GetFileName(x) == filename)) {
                    var localModule = localModules.First(x => Path.GetFileName(x) == filename);

                    byte[] remoteBytes, localBytes;

                    using (var remoteStream = new FileStream(remoteModule, FileMode.Open, FileAccess.Read)) {
                        using (var localStream = new FileStream(localModule, FileMode.Open, FileAccess.Read)) {
                            var md5 = MD5.Create();

                            remoteBytes = md5.ComputeHash(remoteStream);
                            localBytes = md5.ComputeHash(localStream);
                        }
                    }

                    var remoteHash = Convert.ToBase64String(remoteBytes);
                    var localHash = Convert.ToBase64String(localBytes);

                    // if module has been modified
                    if (remoteHash != localHash) {
                        modulesToDownload.Add(remoteModule);
                    }

                    continue;
                }

                // otherwise, it's a new module
                modulesToDownload.Add(remoteModule);
            }

            foreach (var remoteModule in modulesToDownload) {
                var localFilename = string.Format("{0}\\{1}", Session.LocalModuleDir,
                    Path.GetFileName(remoteModule));

                File.Copy(remoteModule, localFilename, true);
            }
        }

        /// <summary>
        ///     Removes any local modules that no longer exist in the remote directory
        /// </summary>
        private void RemoveOrphanedLocalModules()
        {
            var localModules = Directory.GetFiles(Session.LocalModuleDir, "Module.*.dll");

            foreach (var localModulePath in localModules) {
                var filename = Path.GetFileName(localModulePath);

                var remoteModulePath = string.Format("{0}{1}", Settings.Default.ModuleUpdateDir, filename);

                if (!File.Exists(remoteModulePath)) {
                    File.Delete(localModulePath);
                }
            }
        }

        /// <summary>
        ///     Generates the default data file for modules that do not have an existing file
        /// </summary>
        private void GenerateMissingDataFiles()
        {
            var localModules = Directory.GetFiles(Session.LocalModuleDir, "Module.*.dll");

            foreach (var localModulePath in localModules) {
                var assembly = Assembly.LoadFile(localModulePath);

                foreach (var type in assembly.GetTypes()) {
                    var interfaces = type.GetInterfaces();
                    var isModule = interfaces.Contains(typeof (IModule));

                    if (isModule) {
                        var module = (IModule) Activator.CreateInstance(type);

                        module.GenerateDefaultDataFile(Settings.Default.ModuleDataDir);

                        break; // TODO: disable break if more than one module in assembly
                    }
                }
            }
        }

        private IEnumerable<IModule> LoadModules()
        {
            var loadedModules = new List<IModule>();

            var moduleFiles = Directory.GetFiles(Session.LocalModuleDir);

            foreach (var file in moduleFiles) {
                var assembly = Assembly.LoadFile(file);

                foreach (var type in assembly.GetTypes()) {
                    var interfaces = type.GetInterfaces();
                    var isModule = interfaces.Contains(typeof (IModule));

                    if (isModule) {
                        var module = (IModule) Activator.CreateInstance(type);

                        loadedModules.Add(module);
                    }
                }
            }

            return loadedModules;
        }

        private void HandleException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}