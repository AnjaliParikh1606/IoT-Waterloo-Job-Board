USE [master]
GO
/****** Object:  Database [JobBoard]    Script Date: 2019-12-08 4:39:42 PM ******/
CREATE DATABASE [JobBoard]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'JobBoard', FILENAME = N'C:\Users\User\JobBoard.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'JobBoard_log', FILENAME = N'C:\Users\User\JobBoard_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO
ALTER DATABASE [JobBoard] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobBoard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobBoard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobBoard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobBoard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobBoard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobBoard] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobBoard] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [JobBoard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobBoard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobBoard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobBoard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobBoard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobBoard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobBoard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobBoard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobBoard] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JobBoard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobBoard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobBoard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobBoard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobBoard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobBoard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JobBoard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobBoard] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JobBoard] SET  MULTI_USER 
GO
ALTER DATABASE [JobBoard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobBoard] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobBoard] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobBoard] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JobBoard] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JobBoard] SET QUERY_STORE = OFF
GO
USE [JobBoard]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [JobBoard]
GO
/****** Object:  Table [dbo].[AccountInformation]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountInformation](
	[userName] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[roleId] [int] NOT NULL,
 CONSTRAINT [PK_AcountInformation] PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgencyDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencyDetails](
	[agencyId] [int] NOT NULL,
	[agencyName] [nvarchar](50) NOT NULL,
	[agencyWebsite] [nvarchar](50) NOT NULL,
	[agencyPhone] [int] NOT NULL,
	[agencyEmail] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AgencyDetails] PRIMARY KEY CLUSTERED 
(
	[agencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgentDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentDetails](
	[agentId] [int] NOT NULL,
	[agentFirstName] [nvarchar](50) NOT NULL,
	[agenntLastName] [nvarchar](50) NOT NULL,
	[agentPhone] [int] NOT NULL,
	[agentExtensionNumber] [int] NULL,
	[agencyId] [int] NULL,
	[userName] [nvarchar](50) NULL,
 CONSTRAINT [PK_AgentDetails] PRIMARY KEY CLUSTERED 
(
	[agentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidateDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateDetails](
	[candidateID] [int] NOT NULL,
	[candidateFirstName] [nvarchar](50) NULL,
	[candidateLastName] [nvarchar](50) NULL,
	[resumeId] [int] NOT NULL,
	[linkedInId] [int] NOT NULL,
	[userName] [nvarchar](50) NULL,
 CONSTRAINT [PK_CandidateDetails] PRIMARY KEY CLUSTERED 
(
	[candidateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyDetails](
	[companyId] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [nvarchar](50) NULL,
	[companyAddress] [nvarchar](255) NULL,
	[companyCity] [nvarchar](50) NULL,
	[companyPostalCode] [nchar](10) NULL,
	[companyLandLinePhoneNumber] [nchar](10) NULL,
	[companyLandLineExtensionNumber] [nchar](10) NULL,
	[companyEmailId] [nvarchar](50) NULL,
	[companyRegistrationDateTime] [datetime] NULL,
	[companyContactPerson] [varchar](50) NULL,
	[roleId] [int] NOT NULL,
	[userName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[companyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompnaySubscription]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompnaySubscription](
	[subscriptionId] [int] IDENTITY(1,1) NOT NULL,
	[subscriptionStartDate] [datetime] NULL,
	[subscriptionExprityDate] [datetime] NULL,
	[paymentID] [int] NOT NULL,
 CONSTRAINT [PK_CompnaySubscription] PRIMARY KEY CLUSTERED 
(
	[subscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventDetails](
	[eventId] [int] IDENTITY(1,1) NOT NULL,
	[eventName] [nvarchar](50) NOT NULL,
	[eventType] [nvarchar](50) NOT NULL,
	[eventLocation] [nvarchar](50) NOT NULL,
	[eventSratDateTime] [datetime] NOT NULL,
	[eventEndDateTime] [datetime] NOT NULL,
	[eventDescription] [nvarchar](1000) NULL,
	[subscriberEmailId] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventDetails] PRIMARY KEY CLUSTERED 
(
	[eventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobDetails](
	[jobId] [int] IDENTITY(1,1) NOT NULL,
	[jobTitle] [nvarchar](50) NULL,
	[category] [nvarchar](50) NULL,
	[location] [nvarchar](50) NULL,
	[jobtype] [nvarchar](50) NULL,
	[max_salary] [decimal](18, 2) NULL,
	[min_salary] [decimal](18, 2) NULL,
	[jobDescription] [nvarchar](500) NULL,
	[payPeriod] [decimal](18, 0) NULL,
	[numberOfPosition] [int] NULL,
	[jobPostDate] [datetime] NULL,
	[jobExpiryDate] [datetime] NULL,
	[compnayId] [int] NOT NULL,
 CONSTRAINT [PK_JobDetails] PRIMARY KEY CLUSTERED 
(
	[jobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinkedInProfiles]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinkedInProfiles](
	[linkedInId] [int] NOT NULL,
	[ProfilrURL] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LinkedInProfiles] PRIMARY KEY CLUSTERED 
(
	[linkedInId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsLetter]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsLetter](
	[newsletterId] [nchar](10) NOT NULL,
	[discription] [nvarchar](50) NOT NULL,
	[subscriptionEmailId] [nvarchar](50) NULL,
 CONSTRAINT [PK_NewsLetter] PRIMARY KEY CLUSTERED 
(
	[newsletterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetails](
	[paymentID] [int] IDENTITY(1,1) NOT NULL,
	[paymentCardType] [nvarchar](50) NULL,
	[paymentDateTime] [datetime] NULL,
 CONSTRAINT [PK_PaymentDetails] PRIMARY KEY CLUSTERED 
(
	[paymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrationDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationDetails](
	[registrationID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lasttName] [nvarchar](50) NOT NULL,
	[companyName] [nvarchar](50) NULL,
	[email] [nvarchar](50) NOT NULL,
	[contactNumber] [nchar](10) NOT NULL,
	[registrationDateTime] [datetime] NOT NULL,
	[paymentId] [int] NOT NULL,
 CONSTRAINT [PK_RegistrationDetails] PRIMARY KEY CLUSTERED 
(
	[registrationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrationEventDetails]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationEventDetails](
	[registrationID] [int] NOT NULL,
	[eventId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[registrationID] ASC,
	[eventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resume]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resume](
	[resumeId] [int] NOT NULL,
	[filePath] [nvarchar](50) NULL,
 CONSTRAINT [PK_Resume] PRIMARY KEY CLUSTERED 
(
	[resumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[permissionType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebsiteSubscriber]    Script Date: 2019-12-08 4:39:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebsiteSubscriber](
	[subscriberEmailId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WebsiteSubscriber] PRIMARY KEY CLUSTERED 
(
	[subscriberEmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'anjali123@gmail.com', N'@Ngel12345', 2)
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'Dropbox@gmail.com', N'@Ngel12345', 2)
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'ianpilon@gmail.com', N'Iotw@terloo2020', 2)
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'iotwaterloo', N'abc', 1)
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'Microsoft', N'abcxyz', 3)
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'Oracle', N'pqrz123', 1)
GO
INSERT [dbo].[AccountInformation] ([userName], [password], [roleId]) VALUES (N'prof.bhagvat.patel@gmail.com', N'@Bc12345', 2)
GO
SET IDENTITY_INSERT [dbo].[CompanyDetails] ON 
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (1008, N'Iot Waterloo', N'31, Watercress ct', N'kitchener', N'N2E 3S8   ', N'2262680579', N'9946      ', N'abce@gmail.com', CAST(N'2019-12-31T12:59:00.000' AS DateTime), N'Jems robert Patel', 1, NULL)
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (1012, N'Oracle', N'44 Queen Street', N'Toroto', N'N2l 5Y9   ', N'5246254859', N'5623      ', N'rjems@oracle.ca', NULL, N'Robert Jems', 3, N'Oracle')
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (1013, N'Sap', N'44 Queen Street', N'Toroto', N'N2l 5Y9   ', N'5246254859', N'5623      ', N'rjems@oracle.ca', NULL, N'Robert Jems', 3, N'Oracle')
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (2009, N'Iot Waterloo', N'Waterloo Street', N'Waterloo', N'N2L 4B4   ', N'5623895652', N'5241      ', N'Waterloo@waterloo.in', CAST(N'2019-03-12T12:59:00.000' AS DateTime), N'Ian', 1, N'iotwaterloo')
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (2010, N'Microsoft Us', N'xzy street', N'waterloo', N'N2l 5k9   ', N'5263415623', N'4152      ', N'microsoftjems@microsoft.ca', CAST(N'2019-11-25T12:58:00.000' AS DateTime), N'Jems robert', 2, N'Microsoft')
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (2014, N'Agfa', N'xyz', N'waterloo', N'n2l5k9    ', N'5412638974', N'4152      ', N'abc@gmail.com', NULL, N'jems', 2, N'Oracle')
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (3013, N'conestoga', N'abc street', N'abc ', N'N2E 3S8   ', N'5723568962', NULL, N'abc@gmail.com', CAST(N'2019-12-02T12:59:00.000' AS DateTime), N'Jems robert', 3, NULL)
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (3014, N'Oracle', N'waterloo street', N'waterloo ', N'N2L 4G2   ', NULL, NULL, N'anjali123@gmail.com', CAST(N'2019-12-05T12:59:00.000' AS DateTime), N'Jems', 2, N'anjali123@gmail.com')
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (4020, N'Microsoft Us', N'31, Watercress ct', N'kitchener', N'N2E 3S8   ', NULL, NULL, NULL, NULL, N'Anjaliben Parikh', 1, NULL)
GO
INSERT [dbo].[CompanyDetails] ([companyId], [companyName], [companyAddress], [companyCity], [companyPostalCode], [companyLandLinePhoneNumber], [companyLandLineExtensionNumber], [companyEmailId], [companyRegistrationDateTime], [companyContactPerson], [roleId], [userName]) VALUES (4025, N'Ratha Krishna', N'31, Watercress ct', N'kitchener', N'N2E 3S8   ', NULL, NULL, N'Dropbox@gmail.com', CAST(N'2019-12-08T12:59:00.000' AS DateTime), N'Shree', 2, N'Dropbox@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[CompanyDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[JobDetails] ON 
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (4, N'Java Software Developer', N'Intern', N'Kitchnere', N'Full-Time', NULL, NULL, N'This is job has lot of opportunity of expanding career', NULL, 1, CAST(N'2019-12-31T12:59:00.000' AS DateTime), CAST(N'2019-12-31T12:59:00.000' AS DateTime), 2014)
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (6, N'Software Developer', N'Contract', N'Toronto', N'Full-Time', NULL, NULL, N'This job is about software Developer', NULL, 5, CAST(N'2019-12-31T12:59:00.000' AS DateTime), CAST(N'2020-12-31T12:59:00.000' AS DateTime), 1012)
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (8, N'Software Tester', N'Volunteer', N'Waterloo', N'Full-Time', NULL, NULL, N'This job is in Waterloo instead of Toronto', NULL, 1, CAST(N'2019-12-31T12:59:00.000' AS DateTime), CAST(N'2020-01-06T12:59:00.000' AS DateTime), 2014)
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (9, N'Project Manager', N'Volunteer', N'waterloo', N'Full-Time', NULL, NULL, N'This is the description of job', NULL, 2, CAST(N'2019-12-02T12:59:00.000' AS DateTime), CAST(N'2019-12-08T23:58:00.000' AS DateTime), 3013)
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (11, N'software Manager', N'Contract', N'waterloo', N'Part-Time', NULL, NULL, N'This is Job Description', NULL, -1, CAST(N'2019-12-08T12:59:00.000' AS DateTime), CAST(N'2019-12-31T12:59:00.000' AS DateTime), 1008)
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (12, N'Software Developer', N'Contract', N'Kitchnere', N'Part-Time', NULL, NULL, N'This job requirement', NULL, 2, CAST(N'2019-12-08T12:59:00.000' AS DateTime), CAST(N'2019-12-31T12:59:00.000' AS DateTime), 1008)
GO
INSERT [dbo].[JobDetails] ([jobId], [jobTitle], [category], [location], [jobtype], [max_salary], [min_salary], [jobDescription], [payPeriod], [numberOfPosition], [jobPostDate], [jobExpiryDate], [compnayId]) VALUES (13, N'Shopify', N'Contract', N'Waterloo', N'Full-Time', NULL, NULL, N'This is shopify job description', NULL, 2, CAST(N'2019-12-08T12:59:00.000' AS DateTime), CAST(N'2020-01-01T12:59:00.000' AS DateTime), 1008)
GO
SET IDENTITY_INSERT [dbo].[JobDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([roleId], [permissionType]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Role] ([roleId], [permissionType]) VALUES (2, N'Employer')
GO
INSERT [dbo].[Role] ([roleId], [permissionType]) VALUES (3, N'Candidate')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
ALTER TABLE [dbo].[AccountInformation]  WITH CHECK ADD  CONSTRAINT [FK_Role_AccountInformation] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountInformation] CHECK CONSTRAINT [FK_Role_AccountInformation]
GO
ALTER TABLE [dbo].[AgentDetails]  WITH CHECK ADD  CONSTRAINT [FK_AgencyDetails_AgentDetails] FOREIGN KEY([agencyId])
REFERENCES [dbo].[AgencyDetails] ([agencyId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AgentDetails] CHECK CONSTRAINT [FK_AgencyDetails_AgentDetails]
GO
ALTER TABLE [dbo].[AgentDetails]  WITH CHECK ADD  CONSTRAINT [FK_Role_AgentDetails] FOREIGN KEY([userName])
REFERENCES [dbo].[AccountInformation] ([userName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AgentDetails] CHECK CONSTRAINT [FK_Role_AgentDetails]
GO
ALTER TABLE [dbo].[CandidateDetails]  WITH CHECK ADD  CONSTRAINT [FK_CandidateDetails_AccountInformation] FOREIGN KEY([userName])
REFERENCES [dbo].[AccountInformation] ([userName])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CandidateDetails] CHECK CONSTRAINT [FK_CandidateDetails_AccountInformation]
GO
ALTER TABLE [dbo].[CandidateDetails]  WITH CHECK ADD  CONSTRAINT [FK_CandidateDetails_LinkedInProfiles] FOREIGN KEY([linkedInId])
REFERENCES [dbo].[LinkedInProfiles] ([linkedInId])
GO
ALTER TABLE [dbo].[CandidateDetails] CHECK CONSTRAINT [FK_CandidateDetails_LinkedInProfiles]
GO
ALTER TABLE [dbo].[CandidateDetails]  WITH CHECK ADD  CONSTRAINT [FK_CandidateDetails_Resume] FOREIGN KEY([resumeId])
REFERENCES [dbo].[Resume] ([resumeId])
GO
ALTER TABLE [dbo].[CandidateDetails] CHECK CONSTRAINT [FK_CandidateDetails_Resume]
GO
ALTER TABLE [dbo].[CompanyDetails]  WITH CHECK ADD  CONSTRAINT [FK_CompnayAccountInformation] FOREIGN KEY([userName])
REFERENCES [dbo].[AccountInformation] ([userName])
GO
ALTER TABLE [dbo].[CompanyDetails] CHECK CONSTRAINT [FK_CompnayAccountInformation]
GO
ALTER TABLE [dbo].[CompanyDetails]  WITH CHECK ADD  CONSTRAINT [FK_CompnayRole] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[CompanyDetails] CHECK CONSTRAINT [FK_CompnayRole]
GO
ALTER TABLE [dbo].[CompnaySubscription]  WITH CHECK ADD  CONSTRAINT [FK_CompanySubscription_PaymentDetails] FOREIGN KEY([paymentID])
REFERENCES [dbo].[PaymentDetails] ([paymentID])
GO
ALTER TABLE [dbo].[CompnaySubscription] CHECK CONSTRAINT [FK_CompanySubscription_PaymentDetails]
GO
ALTER TABLE [dbo].[EventDetails]  WITH CHECK ADD  CONSTRAINT [FK_EventDetails_WensiteSubscriber] FOREIGN KEY([subscriberEmailId])
REFERENCES [dbo].[WebsiteSubscriber] ([subscriberEmailId])
GO
ALTER TABLE [dbo].[EventDetails] CHECK CONSTRAINT [FK_EventDetails_WensiteSubscriber]
GO
ALTER TABLE [dbo].[JobDetails]  WITH CHECK ADD  CONSTRAINT [FK_JobDetails_CompnayDetails] FOREIGN KEY([compnayId])
REFERENCES [dbo].[CompanyDetails] ([companyId])
GO
ALTER TABLE [dbo].[JobDetails] CHECK CONSTRAINT [FK_JobDetails_CompnayDetails]
GO
ALTER TABLE [dbo].[NewsLetter]  WITH CHECK ADD  CONSTRAINT [FK_WebsiteSubscriber_Newsletter] FOREIGN KEY([subscriptionEmailId])
REFERENCES [dbo].[WebsiteSubscriber] ([subscriberEmailId])
GO
ALTER TABLE [dbo].[NewsLetter] CHECK CONSTRAINT [FK_WebsiteSubscriber_Newsletter]
GO
ALTER TABLE [dbo].[RegistrationDetails]  WITH CHECK ADD  CONSTRAINT [FK_EventRegistration_paymentDetails] FOREIGN KEY([paymentId])
REFERENCES [dbo].[PaymentDetails] ([paymentID])
GO
ALTER TABLE [dbo].[RegistrationDetails] CHECK CONSTRAINT [FK_EventRegistration_paymentDetails]
GO
ALTER TABLE [dbo].[RegistrationEventDetails]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationDetailsEventDetails_EventDetails] FOREIGN KEY([eventId])
REFERENCES [dbo].[EventDetails] ([eventId])
GO
ALTER TABLE [dbo].[RegistrationEventDetails] CHECK CONSTRAINT [FK_RegistrationDetailsEventDetails_EventDetails]
GO
USE [master]
GO
ALTER DATABASE [JobBoard] SET  READ_WRITE 
GO
