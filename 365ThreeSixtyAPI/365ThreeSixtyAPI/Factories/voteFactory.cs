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

        public string createVote(string reviewer, string recipient, string comment)
        {
            reviewerFactory rvFac = new reviewerFactory();
            recipientFactory rcFac = new recipientFactory();

            reviewer newReviewer = rvFac.createReviewer(reviewer);
            recipient newRecipient = rcFac.createRecipient(recipient);

            vote v = new vote();

            //set up
            v.reviewerRef = newReviewer.Ref;
            v.recipientRef = newRecipient.Ref;
            v.rawScore = 100;
            v.comment = comment;
            //factors, these will be used to adapt the weightings later on as part of the machine learning part##todo##
            v.tierFactor = 1;
            v.reviewerFactor = 1;
            v.recipientFactor = 1;
            v.commentFactor = 1;
            // derived scores
            v.tierScore = getTierScore(newReviewer.tier, newRecipient.tier);
            v.reviewerScore = getReviewerScore(newReviewer.reviewsInLastSevenDays);
            v.recipientScore = getRecipientScore(newRecipient.reviewsInLastSevenDays);
            v.commentScore = getCommentScore(comment);
            //final calculation
            v.weightedScore = v.rawScore * v.tierFactor * v.tierScore * v.reviewerFactor * v.reviewerScore * v.recipientFactor * v.recipientScore * v.commentFactor * v.commentScore;

            db.vote.Add(v);
            db.SaveChanges();

            return "Your Comments been recieved, Thanks";
        }

        private double getCommentScore(string comment)
        {
            return 1;
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