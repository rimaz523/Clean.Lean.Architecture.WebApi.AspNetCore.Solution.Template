using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;


public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;

    public ApplicationDbContextInitialiser(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.BlogPosts.Any())
        {
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Deploying your docker image to Minikube",
                Content = "In this tutorial I’ll be showing you how you can quickly set up minikube on your local windows machine, and then deploy a docker image successfully in it.",
                Image = "/blog-preview-url/docker-minikube.png",
                Url = "https://rimazmohommed523.medium.com/deploying-your-docker-image-to-minikube-1ff265722d2c",
                PublishedDate = new DateTimeOffset(new DateTime(2024, 02, 18))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Containerize a .NET Core Web Api App with Docker",
                Content = "In this article I will be showing you how easy it is to containerize your .net core 8.0 web api app using Docker. Although I’m specifically going to show you how to create containers for your .net core app, you can use the same approach to containerize apps in most other programming languages.",
                Image = "/blog-preview-url/dotnet-docker-container.png",
                Url = "https://rimazmohommed523.medium.com/containerize-a-net-core-web-api-app-with-docker-2cdba52a8978",
                PublishedDate = new DateTimeOffset(new DateTime(2024, 02, 08))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "React 101 : Creating your starter React app using Yarn Berry (yarn@3.3.1)",
                Content = "In this article I’ll be showing you how to set up a starter react app in windows using the create-react-app command, configure your editor — VS Code, and version control the app.",
                Image = "/blog-preview-url/reactjs-v1.jpg",
                Url = "https://rimazmohommed523.medium.com/react-101-creating-your-starter-react-app-using-yarn-berry-yarn-3-3-1-e40ed98ec14",
                PublishedDate = new DateTimeOffset(new DateTime(2023, 01, 24))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "React 102 : Configuring code formatting using Prettier, ESLint & Husky",
                Content = "In this article I’ll be diving into setting up pettier, eslint and husky for configuring the code formatting rules for your react js application. I will be using yarn as my package manager.",
                Image = "/blog-preview-url/reactjs-v2.jpg",
                Url = "https://rimazmohommed523.medium.com/react-101-creating-your-starter-react-app-using-yarn-berry-yarn-3-3-1-e40ed98ec14",
                PublishedDate = new DateTimeOffset(new DateTime(2023, 06, 13))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "JMeter Load Testing : Part 1 — Installing JMeter on Windows",
                Content = "I recently had to run some performance load tests against a number of API apps to make sure they can handle the predicted load and identify the point at which performance degraded and the app needed to scale out. JMeter is a pretty impressive tool that can generate a rich set of reports for analysis and is very simple to configure and run if you come from an IT background.",
                Image = "/blog-preview-url/jmeter-v1.jpg",
                Url = "https://rimazmohommed523.medium.com/jmeter-load-testing-part-1-installing-jmeter-on-windows-fa524da15ae0",
                PublishedDate = new DateTimeOffset(new DateTime(2020, 10, 06))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "AZ-303 Azure Architect Technologies Study Guide",
                Content = "I passed my AZ-303 exam in June 2021. The exam consisted of around MCQs and 1 case study. What follows is the study guide I created based on the exam skills outline to help me prepare. Hope this helps you too. Cheers!",
                Image = "/blog-preview-url/azure-architect-study-guide.jpg",
                Url = "https://rimazmohommed523.medium.com/az-303-azure-architect-technologies-study-guide-e0bb6e3e2ee4",
                PublishedDate = new DateTimeOffset(new DateTime(2021, 06, 16))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Applying for Jobs Abroad",
                Content = "I’m a software engineer from Sri Lanka who had approximately 5 years of experience in the software industry before I relocated to New Zealand on a talent work visa. Here's what I learnt.",
                Image = "/blog-preview-url/apply_jobs_abroad.jpg",
                Url = "https://rimazmohommed523.medium.com/applying-for-jobs-abroad-p1-job-portals-resumes-more-f44055be4d36",
                PublishedDate = new DateTimeOffset(new DateTime(2020, 10, 18))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "AZ-500 Azure Security Technologies Study Guide",
                Content = "I passed my Az-500 exam in January 2020. The exam consisted of around 50 MCQs and 1 case study, and had a time limit of 3 hours. What follows is the study guide I created based on the exam skills outline to help me prepare. Hope this helps you too. Cheers!",
                Image = "/blog-preview-url/azure-security-study-guide.jpg",
                Url = "https://rimazmohommed523.medium.com/az-500-azure-security-technologies-study-guide-e42bd819e02d",
                PublishedDate = new DateTimeOffset(new DateTime(2021, 01, 30))
            });
            _context.BlogPosts.Add(new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "AZ-204 Azure Developer Associate Study Guide",
                Content = "I passed my Az-204 exam in September 2020. The exam consisted of around 50 MCQs and 1 case study, and had a time limit of 3 hours. What follows is the study guide I created based on the exam skills outline to help me prepare. Hope this helps you too. Cheers!",
                Image = "/blog-preview-url/azure-developer-study-guide.jpg",
                Url = "https://rimazmohommed523.medium.com/az-204-azure-developer-associate-study-guide-7750b9854fb0",
                PublishedDate = new DateTimeOffset(new DateTime(2021, 01, 26))
            });

            await _context.SaveChangesAsync();
        }
    }
}
