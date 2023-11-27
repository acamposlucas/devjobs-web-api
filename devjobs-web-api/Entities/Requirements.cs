﻿using System.Text.Json.Serialization;

namespace devjobs_web_api.Entities;

public class Requirements
{
    public int Id { get; set; }
    public int JobId { get; set; }
    [JsonIgnore]
    public Job Job { get; set; }
    public string Content { get; set; }
    public ICollection<RequirementsItem> Items { get; set; }
}