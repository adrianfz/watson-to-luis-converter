using Newtonsoft.Json;
using Psbds.WLConverter.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Psbds.WLConverter.Console
{
    class Program
    {

        public static string InputFile { get; set; }

        public static string OutputDirectory { get; set; }

        static void Main(string[] args)
        {
            try
            {
                ValidateInput(args);

                var watsonModel = ReadWatsonWorkspace();


                var luisModel = new LuisModel()
                {
                    Name = watsonModel.Name,
                    Description = watsonModel.Description,
                    Culture = GetLuisCulture(watsonModel.Language),
                    VersionId = "0.1",
                    LuisSchemaVersion = "2.2.0",
                    EntitiesClosedList = FillEntities(watsonModel),
                    Intents = FillIntents(watsonModel),
                    Utterances = FillUtterances(watsonModel)
                };

                using (var writer = new StreamWriter($"{OutputDirectory}/{luisModel.Name}.json"))
                {
                    var json = JsonConvert.SerializeObject(luisModel);
                    writer.Write(json);
                }

                System.Console.WriteLine("Process Finished");
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Error.WriteLine(e.Message);
            }

            System.Console.Read();
        }

        public static LuisUtteranceModel[] FillUtterances(WatsonWorkspaceModel watsonModel)
        {
            var luisUtterances = new List<LuisUtteranceModel>();
            foreach (var intent in watsonModel.Intents)
            {
                var utterances = intent.Examples.Select(x => new LuisUtteranceModel()
                {
                    Intent = intent.Intent,
                    Text = x.Text
                });
                luisUtterances.AddRange(utterances);
            }
            return luisUtterances.ToArray();
        }

        public static LuisIntentModel[] FillIntents(WatsonWorkspaceModel watsonModel)
        {
            return watsonModel.Intents.Select(x => new LuisIntentModel() { Name = x.Intent }).ToArray();
        }

        public static string GetLuisCulture(string watsonCulture)
        {
            switch (watsonCulture)
            {
                case "en":
                    return "en-us";
                case "es":
                    return "es-es";
                default:
                    return watsonCulture;
            }
        }

        public static LuisEntityClosedListsModel[] FillEntities(WatsonWorkspaceModel watsonModel)
        {
            var luisModelEntities = new List<LuisEntityClosedListsModel>();
            foreach (var entity in watsonModel.Entities.Where(x => x.Values.Any()))
            {
                var luisEntity = new LuisEntityClosedListsModel()
                {
                    Name = entity.Entity,
                    SubLists = entity.Values.Select(x => new LuisEntityClosedListSubListModel()
                    {
                        CanonicalForm = x.Value,
                        List = x.Synonyms.Select(s => s).ToArray()
                    }).ToArray()
                };
                luisModelEntities.Add(luisEntity);
            }

            return luisModelEntities.ToArray();
        }

        public static WatsonWorkspaceModel ReadWatsonWorkspace()
        {
            try
            {
                var file = File.ReadAllText(InputFile);

                var model = JsonConvert.DeserializeObject<WatsonWorkspaceModel>(file);

                return model;
            }
            catch (Exception exc)
            {

                throw new JsonSerializationException($"Error Parsing Watson Workspace File:\n{exc.Message}");
            }
        }

        public static void ValidateInput(string[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("Please provide the input file and output directory.\n Ex: dotnet run --project Psbds.WLConverter.Console\\Psbds.WLConverter.Console.csproj \"D:/workspace-watson.json\" \"D:");
            }
            else if (args.Length == 1)
            {
                throw new Exception("Please provide the output directory.\n Ex: dotnet run --project Psbds.WLConverter.Console\\Psbds.WLConverter.Console.csproj \"D:/workspace-watson.json\" \"D:");
            }

            if (!File.Exists(args[0]))
            {
                throw new FileNotFoundException("File Not Found");
            }
            if (!Directory.Exists(args[1]))
            {
                throw new DirectoryNotFoundException("Directory Not Found");
            }

            InputFile = args[0];
            OutputDirectory = args[1];

        }

    }
}
