using eSignUpEBSAPI.Models.Enums;

namespace eSignUpEBSAPI.Helpers
{
    public class CandidateHelper
    {
        public static List<Models.Candidates.CandidateModel>? MapCandidateEnums(List<Models.Candidates.CandidateModel> candidates)
        {
            if (candidates == null || candidates.Count == 0)
            {
                return candidates;
            }

            foreach (var candidate in candidates)
            {
                //Map Title
                if (!string.IsNullOrWhiteSpace(candidate.ListCandidateTitleMapping))
                {
                    // Get ID
                    if (TitleHelper.TryGetID(candidate.ListCandidateTitleMapping, out var titleID))
                    {
                        candidate.ListCandidateTitleID = titleID;
                    }
                    else
                    {
                        candidate.ListCandidateTitleID = null;
                    }
                }

                //Map Emergency Contact Relationship
                if (!string.IsNullOrWhiteSpace(candidate.ListEmergencyContactRelationshipMapping))
                {
                    // Get ID
                    if (EmergencyContactRelationshipHelper.TryGetID(candidate.ListEmergencyContactRelationshipMapping, out var emergencyContactRelationshipID))
                    {
                        candidate.ListEmergencyContactRelationshipID = emergencyContactRelationshipID;
                    }
                    else
                    {
                        candidate.ListEmergencyContactRelationshipID = null;
                    }

                    // Get friendly name
                    candidate.EmergencyContactRelationship = EmergencyContactRelationshipHelper.GetFriendlyNameFromCode(candidate.ListEmergencyContactRelationshipMapping);
                }

                //Map Ethnicity
                if (!string.IsNullOrWhiteSpace(candidate.CandidateEthnicityMapping))
                {
                    // Get ID
                    if (EthnicityHelper.TryGetID(candidate.CandidateEthnicityMapping, out var ethnicityID))
                    {
                        candidate.CandidateEthnicityID = ethnicityID;
                    }
                    else
                    {
                        candidate.CandidateEthnicityID = null;
                    }
                }

                //Map Home Address Country
                if (!string.IsNullOrWhiteSpace(candidate.HomeAddressCountryCodeMapping))
                {
                    // Get ID
                    if (CountryOfNationalityHelper.TryGetID(candidate.HomeAddressCountryCodeMapping, out var homeAddressCountryCodeID))
                    {
                        candidate.HomeAddressCountryCodeID = homeAddressCountryCodeID;
                    }
                    else
                    {
                        candidate.HomeAddressCountryCodeID = null;
                    }

                    // Get friendly name
                    candidate.HomeAddressCountry = CountryOfNationalityHelper.GetFriendlyNameFromCode(candidate.HomeAddressCountryCodeMapping);
                }

                //Map Country of Nationality
                if (!string.IsNullOrWhiteSpace(candidate.CountryOfNationalityMapping))
                {
                    // Get ID
                    if (CountryOfNationalityHelper.TryGetID(candidate.CountryOfNationalityMapping, out var countryOfNationalityID))
                    {
                        candidate.CountryOfNationalityID = countryOfNationalityID;
                    }
                    else
                    {
                        candidate.CountryOfNationalityID = null;
                    }

                    // Get friendly name
                    candidate.CountryOfNationalityName = CountryOfNationalityHelper.GetFriendlyNameFromCode(candidate.CountryOfNationalityMapping);
                }

                //Map Religious Identity
                if (!string.IsNullOrWhiteSpace(candidate.CandidateReligiousIdentityMapping))
                {
                    // Get ID
                    if (ReligiousIdentityHelper.TryGetID(candidate.CandidateReligiousIdentityMapping, out var religiousIdentityID))
                    {
                        candidate.CandidateReligiousIdentityID = religiousIdentityID;
                    }
                    else
                    {
                        candidate.CandidateReligiousIdentityID = null;
                    }

                    // Get friendly name
                    candidate.CandidateReligiousIdentityName = ReligiousIdentityHelper.GetFriendlyNameFromCode(candidate.CandidateReligiousIdentityMapping);
                }

                //Map Disability Learning Difficulty
                if (!string.IsNullOrWhiteSpace(candidate.DisabilityLearningDifficultiesPrimaryMapping))
                {
                    // Get ID
                    if (DisabilityLearningDifficultyHelper.TryGetID(candidate.DisabilityLearningDifficultiesPrimaryMapping, out var disabilityLearningDifficultyID))
                    {
                        candidate.DisabilityLearningDifficultiesPrimaryID = disabilityLearningDifficultyID;
                    }
                    else
                    {
                        candidate.DisabilityLearningDifficultiesPrimaryID = null;
                    }

                    // Get friendly name
                    candidate.DisabilityLearningDifficultiesPrimaryName = DisabilityLearningDifficultyHelper.GetFriendlyNameFromCode(candidate.DisabilityLearningDifficultiesPrimaryMapping);
                }

                //Map Candidate Highest Level
                if (!string.IsNullOrWhiteSpace(candidate.CandidateHighestLevelMapping))
                {
                    // Get ID
                    if (HighestLevelHelper.TryGetID(candidate.CandidateHighestLevelMapping, out var candidateHighestLevelID))
                    {
                        candidate.CandidateHighestLevelID = candidateHighestLevelID;
                    }
                    else
                    {
                        candidate.CandidateHighestLevelID = null;
                    }
                }

                //Map Nationality
                if (!string.IsNullOrWhiteSpace(candidate.NationalityMapping))
                {
                    // Get friendly name
                    candidate.Nationality = CountryOfNationalityHelper.GetFriendlyNameFromCode(candidate.NationalityMapping);
                }

                //Map Gender Identity
                if (!string.IsNullOrWhiteSpace(candidate.ListGenderIdentityMapping))
                {
                    // Get ID
                    if (GenderIdentityHelper.TryGetID(candidate.ListGenderIdentityMapping, out var genderIdentityID))
                    {
                        candidate.ListGenderIdentityID = genderIdentityID;
                    }
                    else
                    {
                        candidate.ListGenderIdentityID = null;
                    }
                }
            }

            return candidates;
        }
    }
}
