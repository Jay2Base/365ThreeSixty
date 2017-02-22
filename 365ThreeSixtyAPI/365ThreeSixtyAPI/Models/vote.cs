using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _365ThreeSixtyAPI.Models
{
    public class vote
    {
    public int id { get; set; }
    public int reviewerRef { get; set; }
    public int recipientRef { get; set; }
    public int rawScore { get; set; }
    public double weightedScore { get; set; }
    public string comment { get; set; }
    public double commentFactor { get; set; }
    public double commentScore { get; set; }
    public double tierFactor { get; set; }
    public double tierScore { get; set; }
    public double reviewerFactor { get; set; }
    public double reviewerScore { get; set; }
    public double recipientFactor { get; set; }
    public double recipientScore { get; set; }
    public DateTime voteSubmittedAt { get; set; }
    public string userAccountId { get; set; }
    }
}