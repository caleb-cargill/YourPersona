using Newtonsoft.Json;

public class Annotations
{
    public bool bold { get; set; }
    public bool italic { get; set; }
    public bool strikethrough { get; set; }
    public bool underline { get; set; }
    public bool code { get; set; }
    public string color { get; set; }
}

public class CreatedBy
{
    public string @object { get; set; }
    public string id { get; set; }
}

public class LastEditedBy
{
    public string @object { get; set; }
    public string id { get; set; }
}

public class MultiSelect
{
    public string id { get; set; }
    public string type { get; set; }
    public List<MultiSelect> multi_select { get; set; }
}

public class MultiSelect2
{
    public string id { get; set; }
    public string name { get; set; }
    public string color { get; set; }
}

public class Name
{
    public string id { get; set; }
    public string type { get; set; }
    public List<Title> title { get; set; }
}

public class Parent
{
    public string type { get; set; }
    public string database_id { get; set; }
}

public class Properties
{
    [JsonProperty("Multi-select")]
    public MultiSelect Multiselect { get; set; }
    public Name Name { get; set; }
}

public class Response
{
    public string @object { get; set; }
    public string id { get; set; }
    public DateTime created_time { get; set; }
    public DateTime last_edited_time { get; set; }
    public CreatedBy created_by { get; set; }
    public LastEditedBy last_edited_by { get; set; }
    public object cover { get; set; }
    public object icon { get; set; }
    public Parent parent { get; set; }
    public bool archived { get; set; }
    public bool in_trash { get; set; }
    public Properties properties { get; set; }
    public string url { get; set; }
    public object public_url { get; set; }
    public string request_id { get; set; }
}

public class Text
{
    public string content { get; set; }
    public object link { get; set; }
}

public class Title
{
    public string type { get; set; }
    public Text text { get; set; }
    public Annotations annotations { get; set; }
    public string plain_text { get; set; }
    public object href { get; set; }
}
