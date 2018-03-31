using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Judge : IJudge
{
    private OrderedSet<int> users = new OrderedSet<int>();
    private OrderedSet<int> contests = new OrderedSet<int>();
    private OrderedBag<Submission> submissions = new OrderedBag<Submission>();

    public void AddContest(int contestId)
    {
        this.contests.Add(contestId);
    }

    public void AddUser(int userId)
    {
        this.users.Add(userId);
    }

    public void AddSubmission(Submission submission)
    {
        if (this.contests.Contains(submission.ContestId) && this.users.Contains(submission.UserId))
        {
            this.submissions.Add(submission);
            return;
        }
        throw new InvalidOperationException();
    }

    public void DeleteSubmission(int submissionId)
    {
        this.submissions.Remove(this.submissions.First(sub => sub.Id == submissionId));
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.submissions.OrderBy(sub => sub.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.users;
    }

    public IEnumerable<int> GetContests()
    {
        return this.contests;
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return this.submissions.Where(val => val.Type == submissionType && val.Points >= minPoints && val.Points <= maxPoints);
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        var results = this.submissions.Where(val => val.UserId == userId)
            .OrderByDescending(sub => sub.Points).ThenBy(sub => sub.Id);
        return results.Select(sub => sub.ContestId);
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        return this.submissions.Where(val => val.UserId == userId && val.ContestId == contestId && val.Points == points);
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        var values = this.submissions.Where(v => v.Type.Equals(submissionType));
        return values.Select(val => val.ContestId);
    }
}
