using UnityEngine; 
using VoidLine_LibaryOfStructures; 
using RMC.SaveFile.SaveComposition;
using System.IO;
using System.Collections.Generic;
using System;

namespace RMC.SaveFile.SaveSerialice 
{
    class Path_List
    {
        public static readonly string RotPath = Application.persistentDataPath;
        
        //directory 
        public static readonly string DirectoryName = "SaveFiles"; 
        public static readonly string Directory_PathSaveFile = Path.Combine(RotPath,DirectoryName);

        //SaveFile

        public static readonly string SaveFile_Path = Path.Combine(Directory_PathSaveFile, "SaveFile.json");


    }
    class SerialiceGameData 
    {
        public static void Serialize_GameData<SaveData>(SaveData Game_data, string Save_FilePath)
        {
            
        }
    }

    class Gen_File_Requirements
    {
        
        public static void GenDirectory (string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (DirectoryNotFoundException FailOnGenDirectory)
            {
                Debug.Log($"[D/] {FailOnGenDirectory}");
            }
        }

        public static void GenFile (string path)
        {
            try
            {
                File.Create(path).Close(); 
            } 
            catch (FileNotFoundException FailonGenFile)
            {
                Debug.Log($"[F/] {FailonGenFile}");
            }
        }

        //buscar un metodo que haga los archivos solo en la primera inicializacion del programa

    }

    class GameFile
    {
        void SaveFileWrite<t>(t data, string SAveFilePath)
        {
            //Make Events for Loading and charging
            //Put the JS serialziation
        }
    }

} 
