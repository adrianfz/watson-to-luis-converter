using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psbds.WLConverter.Core.Model
{
    [Serializable]
    public class LuisModel
    {

        [JsonRequired]
        [JsonProperty("luis_schema_version")]
        public string LuisSchemaVersion { get; set; }

        [JsonRequired]
        [JsonProperty("versionId")]
        public string VersionId { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonProperty("culture")]
        public string Culture { get; set; }

        [JsonRequired]
        [JsonProperty("intents")]
        public LuisIntentModel[] Intents { get; set; } = { };

        [JsonRequired]
        [JsonProperty("composites")]
        public object[] CompositeEntities { get; set; } = { };

        [JsonRequired]
        [JsonProperty("entities")]
        public LuisIntentModel[] Entities { get; set; } = { };

        [JsonRequired]
        [JsonProperty("regex_entities")]
        public LuisEntityRegexModel[] RegexEntities { get; set; } = { };

        [JsonRequired]
        [JsonProperty("closedLists")]
        public LuisEntityClosedListsModel[] EntitiesClosedList { get; set; } = { };

        [JsonRequired]
        [JsonProperty("bing_entities")]
        public string[] BingEntities { get; set; } = { };

        [JsonRequired]
        [JsonProperty("model_features")]
        public LuisModelFeatureModel[] ModelFeatures { get; set; } = { };

        [JsonRequired]
        [JsonProperty("regex_features")]
        public string[] RegexFeatures { get; set; } = { };

        [JsonRequired]
        [JsonProperty("utterances")]
        public LuisUtteranceModel[] Utterances { get; set; } = { };

    }


    [Serializable]
    public class LuisIntentModel
    {

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

    }

    [Serializable]
    public class LuisEntityModel
    {

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

    }

    [Serializable]
    public class LuisEntityRegexModel
    {

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("regexPattern")]
        public string RegexPattern { get; set; }
    }

    [Serializable]
    public class LuisEntityClosedListsModel
    {

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("subLists")]
        public LuisEntityClosedListSubListModel[] SubLists { get; set; } = { };

    }

    [Serializable]
    public class LuisEntityClosedListSubListModel
    {

        [JsonRequired]
        [JsonProperty("canonicalForm")]
        public string CanonicalForm { get; set; }

        [JsonRequired]
        [JsonProperty("list")]
        public string[] List { get; set; }

    }

    [Serializable]
    public class LuisModelFeatureModel
    {

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("mode")]
        public bool Mode { get; set; }

        [JsonRequired]
        [JsonProperty("words")]
        public string Words { get; set; }

        [JsonRequired]
        [JsonProperty("activated")]
        public bool Activated { get; set; }

    }

    [Serializable]
    public class LuisUtteranceModel
    {

        [JsonRequired]
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonRequired]
        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonRequired]
        [JsonProperty("entities")]
        public LuisUtteranceEntityModel[] Entities { get; set; } = { };

    }

    [Serializable]
    public class LuisUtteranceEntityModel
    {
        [JsonRequired]
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonRequired]
        [JsonProperty("startPos")]
        public int StartPos { get; set; }

        [JsonRequired]
        [JsonProperty("endPos")]
        public int EndPos { get; set; }

    }
}
