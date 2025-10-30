using eSignUpEBSAPI.Models.Enums;

namespace eSignUpEBSAPI.Helpers
{
    public class DisabilityLearningDifficultyResultHelper
    {
        public static List<Models.Candidates.CandidateDisabilityLearningDifficultyResultModel>? MapDisabilityLearningDifficultyResultEnums(List<Models.Candidates.CandidateDisabilityLearningDifficultyResultModel> difficulties)
        {
            if (difficulties == null || difficulties.Count == 0)
            {
                return difficulties;
            }

            foreach (var difficulty in difficulties)
            {
                //Map Disability Learning Difficulty
                if (!string.IsNullOrWhiteSpace(difficulty.CandidateDisabilityLearningDifficultiesMapping))
                {
                    // Get ID
                    if (DisabilityLearningDifficultyHelper.TryGetID(difficulty.CandidateDisabilityLearningDifficultiesMapping, out var disabilityLearningDifficultyID))
                    {
                        difficulty.CandidateDisabilityLearningDifficultiesID = disabilityLearningDifficultyID;
                    }
                    else
                    {
                        difficulty.CandidateDisabilityLearningDifficultiesID = null;
                    }

                    // Get friendly name
                    difficulty.Name = DisabilityLearningDifficultyHelper.GetFriendlyNameFromCode(difficulty.CandidateDisabilityLearningDifficultiesMapping);
                }
            }

            return difficulties;
        }
    }
}
