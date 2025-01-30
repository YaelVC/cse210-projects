using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Frontend Developer";
        job1._company = "Blautech";
        job1._startDate = new DateTime(2020, 5, 11);
        job1._endDate = new DateTime(2021, 10, 13);

        Job job2 = new Job();
        job2._jobTitle = "Frontend Developer";
        job2._company = "Sngular";
        job2._startDate = new DateTime(2021, 10, 15);
        job2._endDate = new DateTime(2022, 7, 11);

        Resume myResume = new Resume();
        myResume._name = "Dayniz Velasco";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);   

        myResume.Display();
    }
}

