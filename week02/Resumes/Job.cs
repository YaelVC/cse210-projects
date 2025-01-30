using System;
public class Job {
    public string _jobTitle;
    public string _company;
    public DateTime _startDate;
    public DateTime _endDate;

    //A method that returns the job title, company, and dates of employment
    public void DisplayJobInformation() {
        Console.WriteLine($"{_jobTitle} at {_company} from {_startDate.ToString("yyyy-MM")} to {_endDate.ToString("yyyy-MM")}");
    }

}