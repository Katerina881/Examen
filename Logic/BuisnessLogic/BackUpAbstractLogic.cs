﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Logic.BuisnessLogic
{
    public abstract class BackUpAbstractLogic
    {
        public void CreateArchive(string folderName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderName);

                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }

                string fileName = $"{folderName}";

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                Assembly assem = GetAssembly();

                var dbsets = GetFullList();

                //MethodInfo method = GetType().BaseType.GetTypeInfo().GetDeclaredMethod("SaveToFile");

                foreach (var set in dbsets)
                {
                    var elem =
                    assem.CreateInstance(set.PropertyType.GenericTypeArguments[0].FullName);
                    //MethodInfo generic = method.MakeGenericMethod(elem.GetType());
                    //generic.Invoke(this, new object[] { folderName });
                    elem.GetType().InvokeMember("SaveToFile", BindingFlags.InvokeMethod | BindingFlags.Public, null, null, new object[] {folderName});
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveToFile<T>(string folderName) where T : class, new()
        {
            var records = GetList<T>();
            T obj = new T();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(string.Format("{0}/{1}.json", folderName, obj.GetType().Name), FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, records);
            }
        }

        protected abstract Assembly GetAssembly();

        protected abstract List<PropertyInfo> GetFullList();

        protected abstract List<T> GetList<T>() where T : class, new();
    }
}
