using CSAc4yClass.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSGeneratorLib
{
    public class Program
    {

        #region constant


        #endregion // constants

        #region base functions


        #endregion // base functions

        public static void MainMethod(string _inpath, string _outpath, string _defaultNamespace, string templatesFolder)
        {

            //Date: 2019. 11. 09. 18:30

            if (!Directory.Exists(_outpath + "PrePrcessed"))
                Directory.CreateDirectory(_outpath + "PreProcessed");

            if (!Directory.Exists(_outpath + "Algebra"))
                Directory.CreateDirectory(_outpath + "Algebra");

            if (!Directory.Exists(_outpath + "Final"))
                Directory.CreateDirectory(_outpath + "Final");

            string[] files =
                 Directory.GetFiles(_inpath, "*.xml", SearchOption.TopDirectoryOnly);

            CSPersistentGeneratorLib.EntityGenerate.entityGenerateMethods(files, _defaultNamespace, _outpath, templatesFolder);

            foreach (var _file in files)
            {
                string _filename = Path.GetFileNameWithoutExtension(_file);
                Console.WriteLine(_filename);

                Ac4yClass ac4y = DeserialiseMethod.deser(_file);

                GenerateClass.generateClass(ac4y, _outpath, files, _defaultNamespace, templatesFolder);
            }
        }
    }
}