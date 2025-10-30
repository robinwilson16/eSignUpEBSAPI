using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSignUpEBSAPI.Migrations
{
    /// <inheritdoc />
    public partial class ResetDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnRefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ULN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EthnicityILRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderDifferentToSex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LLDDHealthProb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NINumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorAttain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddLine4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateCreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEHCPEmployerPermission = table.Column<bool>(type: "bit", nullable: true),
                    HasEHCP = table.Column<bool>(type: "bit", nullable: true),
                    NASCandidateID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSAdditionalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivingAtAddressSince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSNeedsDifficulty = table.Column<bool>(type: "bit", nullable: true),
                    InCare = table.Column<bool>(type: "bit", nullable: true),
                    LeftCareRecently = table.Column<bool>(type: "bit", nullable: true),
                    SchoolLastAttended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactTelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactRelationshipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARCCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARCCardIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAuthorityReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAuthorityIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyMemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndorsementReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingLicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialUseEUCitizen = table.Column<bool>(type: "bit", nullable: true),
                    OfficialUseOtherEvidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialUseEvidenceEmpEgPAYE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateRegistrationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyAtAnotherCollege = table.Column<bool>(type: "bit", nullable: true),
                    StudyAtAnotherCollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexualOrientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexualOrientationSelfDescribe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentGuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentGuardianHomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentGuardianHomePostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentGuardianTelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentGuardianEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryLivingPast3Years = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateReligiousIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSNeedsExtraHelp = table.Column<bool>(type: "bit", nullable: true),
                    LSNeedsExtraHelpWith = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InCareEmployerPermission = table.Column<bool>(type: "bit", nullable: true),
                    SchoolingInterupted = table.Column<bool>(type: "bit", nullable: true),
                    OffenderInCommunity = table.Column<bool>(type: "bit", nullable: true),
                    UnspentConvictions = table.Column<bool>(type: "bit", nullable: true),
                    SchoolAt16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentSignatureObtained = table.Column<bool>(type: "bit", nullable: true),
                    StudentSignatureObtainedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSetID = table.Column<int>(type: "int", nullable: true),
                    CandidateEligibilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CandidateDocument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualifictionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateDocument_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CandidateExtraFields",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    ApprenticeshipVacancy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviouslyStudiedInUK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviouslyStudiedAtCollege = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousCollegeIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorLearningRecognition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeEducated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastSchoolStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastSchoolLeavingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfExam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExtraFields", x => x.CandidateID);
                    table.ForeignKey(
                        name: "FK_CandidateExtraFields_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateNote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateNote_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateQualification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualificationReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualificationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestAward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateQualification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateQualification_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPreference",
                columns: table => new
                {
                    ContactPreferenceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContPrefDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContPrefType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContPrefCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPreference", x => x.ContactPreferenceID);
                    table.ForeignKey(
                        name: "FK_ContactPreference_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CustomField",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomField_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EnglishAndMathsQualification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BKSBResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishAndMathsQualification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnglishAndMathsQualification_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerEmploymentStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpStat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerEmploymentStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LearnerEmploymentStatus_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LLDDAndHealthProblem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LLDDDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LLDDCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryLLDD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LLDDAndHealthProblem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LLDDAndHealthProblem_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LLDDAndHealthProblemPeopleSoft",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LLDDDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LLDDCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryLLDD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LLDDAndHealthProblemPeopleSoft", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LLDDAndHealthProblemPeopleSoft_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PlacedRecruitment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOTJTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeSites = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedUpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingPlanOTJHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursPerWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPartTimeHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMonths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPLReductionInWeeks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubcontractorUKPRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NegotiatedRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPACost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TNP1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPLReductionPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprenticeshipStandardCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprenticeshipStandardTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprenticeshipStandardVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprenticeshipVacancyTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CohortRefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundingStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgressReviewFrequencyInWeeks = table.Column<int>(type: "int", nullable: true),
                    ProgressReviewEstimatedDates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndpointAssessorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndpointAssessorReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyAccountManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadRecruitmentOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subcontractor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubcontractorContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubcontractorContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnrolled = table.Column<bool>(type: "bit", nullable: true),
                    TotalRPLOTJHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    PlannedSkillScanHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacedRecruitment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlacedRecruitment_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatusMonitoring",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESMTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESMCodeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESMCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnerEmploymentStatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatusMonitoring", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmploymentStatusMonitoring_LearnerEmploymentStatus_LearnerEmploymentStatusID",
                        column: x => x.LearnerEmploymentStatusID,
                        principalTable: "LearnerEmploymentStatus",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ApprenticeshipEmployer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyID = table.Column<int>(type: "int", nullable: false),
                    EmployerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDRSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyEmployerSiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyEmployerSiteAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyEmployerSiteAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyEmployerSiteTown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyEmployerSitePostCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprenticeshipEmployer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApprenticeshipEmployer_PlacedRecruitment_VacancyID",
                        column: x => x.VacancyID,
                        principalTable: "PlacedRecruitment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnglishMathsComponent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionalSkillLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryLead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: true),
                    StudyTowards = table.Column<bool>(type: "bit", nullable: true),
                    TakeExam = table.Column<bool>(type: "bit", nullable: true),
                    TotalHours = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    FundingSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacedRecruitmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishMathsComponent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnglishMathsComponent_PlacedRecruitment_PlacedRecruitmentID",
                        column: x => x.PlacedRecruitmentID,
                        principalTable: "PlacedRecruitment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HouseholdSituation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseholdSituationDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnDelFAMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnDelFAMCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacedRecruitmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdSituation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HouseholdSituation_PlacedRecruitment_PlacedRecruitmentID",
                        column: x => x.PlacedRecruitmentID,
                        principalTable: "PlacedRecruitment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OnboardingDocument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignaturesCollected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignaturesRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentTypeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacedRecruitmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OnboardingDocument_PlacedRecruitment_PlacedRecruitmentID",
                        column: x => x.PlacedRecruitmentID,
                        principalTable: "PlacedRecruitment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprenticeshipEmployer_VacancyID",
                table: "ApprenticeshipEmployer",
                column: "VacancyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocument_CandidateID",
                table: "CandidateDocument",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateNote_CandidateID",
                table: "CandidateNote",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateQualification_CandidateID",
                table: "CandidateQualification",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPreference_CandidateID",
                table: "ContactPreference",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomField_CandidateID",
                table: "CustomField",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentStatusMonitoring_LearnerEmploymentStatusID",
                table: "EmploymentStatusMonitoring",
                column: "LearnerEmploymentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_EnglishAndMathsQualification_CandidateID",
                table: "EnglishAndMathsQualification",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_EnglishMathsComponent_PlacedRecruitmentID",
                table: "EnglishMathsComponent",
                column: "PlacedRecruitmentID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdSituation_PlacedRecruitmentID",
                table: "HouseholdSituation",
                column: "PlacedRecruitmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerEmploymentStatus_CandidateID",
                table: "LearnerEmploymentStatus",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_LLDDAndHealthProblem_CandidateID",
                table: "LLDDAndHealthProblem",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_LLDDAndHealthProblemPeopleSoft_CandidateID",
                table: "LLDDAndHealthProblemPeopleSoft",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingDocument_PlacedRecruitmentID",
                table: "OnboardingDocument",
                column: "PlacedRecruitmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedRecruitment_CandidateID",
                table: "PlacedRecruitment",
                column: "CandidateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprenticeshipEmployer");

            migrationBuilder.DropTable(
                name: "CandidateDocument");

            migrationBuilder.DropTable(
                name: "CandidateExtraFields");

            migrationBuilder.DropTable(
                name: "CandidateNote");

            migrationBuilder.DropTable(
                name: "CandidateQualification");

            migrationBuilder.DropTable(
                name: "ContactPreference");

            migrationBuilder.DropTable(
                name: "CustomField");

            migrationBuilder.DropTable(
                name: "EmploymentStatusMonitoring");

            migrationBuilder.DropTable(
                name: "EnglishAndMathsQualification");

            migrationBuilder.DropTable(
                name: "EnglishMathsComponent");

            migrationBuilder.DropTable(
                name: "HouseholdSituation");

            migrationBuilder.DropTable(
                name: "LLDDAndHealthProblem");

            migrationBuilder.DropTable(
                name: "LLDDAndHealthProblemPeopleSoft");

            migrationBuilder.DropTable(
                name: "OnboardingDocument");

            migrationBuilder.DropTable(
                name: "LearnerEmploymentStatus");

            migrationBuilder.DropTable(
                name: "PlacedRecruitment");

            migrationBuilder.DropTable(
                name: "Candidate");
        }
    }
}
