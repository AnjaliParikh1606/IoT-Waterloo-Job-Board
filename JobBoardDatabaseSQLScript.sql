USE [master]
GO
/****** Object:  Database [JobBoard]    Script Date: 2019-11-18 1:00:43 PM ******/
CREATE DATABASE [JobBoard]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobBoard', FILENAME = N'C:\Users\User\JobBoard.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobBoard_log', FILENAME = N'C:\Users\User\JobBoard_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
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
/****** Object:  Table [dbo].[AccountInformation]    Script Date: 2019-11-18 1:00:43 PM ******/
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
/****** Object:  Table [dbo].[AgencyDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[AgentDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[CandidateDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[CompanyDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[CompnaySubscription]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[EventDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[JobDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobDetails](
	[jobId] [int] IDENTITY(1,1) NOT NULL,
	[jobTitle] [nvarchar](50) NOT NULL,
	[category] [nvarchar](50) NOT NULL,
	[location] [nvarchar](50) NOT NULL,
	[jobtype] [nvarchar](50) NOT NULL,
	[max_salary] [decimal](18, 2) NOT NULL,
	[min_salary] [decimal](18, 2) NOT NULL,
	[jobDescription] [nvarchar](500) NOT NULL,
	[payPeriod] [decimal](18, 0) NOT NULL,
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
/****** Object:  Table [dbo].[LinkedInProfiles]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[NewsLetter]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[RegistrationDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[RegistrationEventDetails]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[Resume]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 2019-11-18 1:00:44 PM ******/
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
/****** Object:  Table [dbo].[WebsiteSubscriber]    Script Date: 2019-11-18 1:00:44 PM ******/
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
