using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psbds.WLConverter.Core.Model
{
    [Serializable]
    public class WatsonWorkspaceModel
    {

        [JsonProperty("workspace_id")]
        public string WorkspaceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public WatsonWorkspaceMetadataModel Metadata { get; set; }

        [JsonProperty("intents")]
        public WatsonWorkspaceIntentModel[] Intents { get; set; }

        [JsonProperty("entities")]
        public WatsonWorkspaceEntityModel[] Entities { get; set; }

        [JsonProperty("dialog_nodes")]
        public WatsonWorkspaceDialogModel[] Dialog_Nodes { get; set; }

        [JsonProperty("counterexamples")]
        public WatsonWorkspaceCounterExampleModel[] CounterExamples { get; set; }

        [JsonProperty("learning_opt_out")]
        public bool LearningOptOut { get; set; }

    }

    [Serializable]
    public class WatsonWorkspaceMetadataModel
    {
        [JsonProperty("api_version")]
        public WatsonWorkspaceMetadataApiVersionModel ApiVersion { get; set; }

        [JsonProperty("from-sample")]
        public bool FromSample { get; set; }

    }

    [Serializable]
    public class WatsonWorkspaceMetadataApiVersionModel
    {

        [JsonProperty("minor_version")]
        public string MinorVersion { get; set; }

        [JsonProperty("major_version")]
        public string MajorVersion { get; set; }

    }


    [Serializable]
    public class WatsonWorkspaceIntentModel
    {

        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("examples")]
        public WatsonWorkspaceIntentExampleModel[] Examples { get; set; }

    }

    [Serializable]
    public class WatsonWorkspaceIntentExampleModel
    {

        [JsonProperty("text")]
        public string Text { get; set; }

    }

    [Serializable]
    public class WatsonWorkspaceEntityModel
    {

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("values")]
        public WatsonWorkspaceEntityValueModel[] Values { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

    }

    [Serializable]
    public class WatsonWorkspaceEntityValueModel
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("synonyms")]
        public string[] Synonyms { get; set; }

    }

    [Serializable]
    public class WatsonWorkspaceDialogModel
    {

    }

    [Serializable]
    public class WatsonWorkspaceCounterExampleModel
    {

        [JsonProperty("text")]
        public string Text { get; set; }

    }

}
