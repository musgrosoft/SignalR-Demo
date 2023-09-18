using Hangfire;

namespace WebApplication3;

public interface ICoverLetterGenerator
{
    void GenerateCoverLetter(string userName);
    void ClearCache();
}

public class CoverLetterGenerator : ICoverLetterGenerator
{
    static List<string> users = new();

    public void GenerateCoverLetter(string userName)
    {
        if (!users.Contains(userName))
        {
            //track who we are making cover letters for, if someone reconnects, don't start regenerating
            users.Add(userName);

            //pretend progress is being made and message user
            Random rnd = new Random();
            int total = 0;
            for (int i = 1; i < 100; i++)
            {
                int rand = rnd.Next(3, 10);
                total += rand;

                BackgroundJob.Schedule<IMyHubHelper>(
                    hubHelper => hubHelper.SendOutAlert(userName, $"I've been generating your Cover Letter for {total} sec, it is {i}% complete"),
                    TimeSpan.FromSeconds(total)

                );

            }
        }

    }

    public void ClearCache()
    {
        users=new();

    }
}