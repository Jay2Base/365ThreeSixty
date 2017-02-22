using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _365ThreeSixtyAPI.Factories;
using _365ThreeSixtyAPI.Models;



namespace _365ThreeSixtyAPI.Factories

{
    public class voteFactory
    {
        public _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();

        public voteResponse createVote(newVote newVote)
        {
            reviewerFactory rvFac = new reviewerFactory();
            recipientFactory rcFac = new recipientFactory();

            reviewer newReviewer = rvFac.createReviewer(newVote.reviewer, newVote.userAccountId);
            recipient newRecipient = rcFac.createRecipient(newVote.recipient, newVote.userAccountId);

            vote v = new vote();

            //set up
            v.userAccountId = newVote.userAccountId;
            v.reviewerRef = newReviewer.Ref;
            v.recipientRef = newRecipient.Ref;
            v.rawScore = 100;
            v.comment = newVote.comment;
            v.voteSubmittedAt = DateTime.Now;
            //factors, these will be used to adapt the weightings later on as part of the machine learning part##todo##
            v.tierFactor = 1;
            v.reviewerFactor = 1;
            v.recipientFactor = 1;
            v.commentFactor = 1;
            // derived scores
            v.tierScore = getTierScore(newReviewer.tier, newRecipient.tier);
            v.reviewerScore = getReviewerScore(newReviewer.reviewsInLastSevenDays);
            v.recipientScore = getRecipientScore(newRecipient.reviewsInLastSevenDays);
            v.commentScore = getCommentScore(newVote.comment);
            
            //final calculation
            v.weightedScore = v.rawScore * v.tierFactor * v.tierScore * v.reviewerFactor * v.reviewerScore * v.recipientFactor * v.recipientScore * v.commentFactor * v.commentScore;

            db.vote.Add(v);
            db.SaveChanges();

            voteResponse vr = new voteResponse();
            vr.recipient = newVote.recipient;
            vr.reviewer = newVote.reviewer;
            vr.voteMessage = "Your been recieved and counted, thanks";

            return vr;
        }

        private double getCommentScore(string comment)
        {
            //tidy and add words to a list
            char[] punc = { ',', '.', ';', ':', ' ', '?', '!' };
            string[] commentWords = comment.Split();

            List<string> commentList = new List<string>();

            foreach (string word in commentWords)
            {
                commentList.Add(word.TrimEnd(punc));
            }

            //get the keywords
            List<string> kw = db.keywordDictionary.Select(x => x.keyword).ToList();

            //compare the comment words with the keywords
            fuzzyMatch fm = new fuzzyMatch();
            double totalMatchScore = 0;
            foreach (string word in kw)
            {
                foreach (string com in commentWords)
                {
                    double matchrate = fm.FuzzyPercent(word, com);
                    if (matchrate > 0.8)
                    {
                        totalMatchScore = totalMatchScore + 1;
                    }

                }
            }

            int numberOfKeywords = kw.Count;
            if (totalMatchScore > numberOfKeywords)
            {
                totalMatchScore = 2;
            }
            else
            {
                totalMatchScore = 1 + (totalMatchScore / numberOfKeywords);
            }
               return totalMatchScore;
            }
        

        private double getRecipientScore(int reviewsInLastSevenDays)
        {
            double getRecipientScore = Math.Pow(0.9, reviewsInLastSevenDays);
            return getRecipientScore;
        }

        private double getReviewerScore(int reviewsInLastSevenDays)
        {
            double getReviewerScore = Math.Pow(0.9,reviewsInLastSevenDays);
            return getReviewerScore;
        }

        private double getTierScore(int reviewerTier, int recipientTier)
        {
            if (reviewerTier >= recipientTier)
            {
                double deltaScore = 1 + (reviewerTier - recipientTier) / 10;
                return deltaScore;
            }
            else
            {
                double deltaScore = 1 + (recipientTier - reviewerTier) / 10;
                return deltaScore;
            }

        }
    }
}