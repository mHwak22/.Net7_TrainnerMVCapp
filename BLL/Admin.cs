using DAL.Connected;
using BOL;

namespace BLL;


public class Admin
{
    public List<Trainer> GetAllTrainers()
    {
        List<Trainer> allTrainers = new List<Trainer>();
        allTrainers = DBManager.GetAllTrainers();
        return allTrainers;
    }

    public bool AddTrainer(Trainer trainer)
    {
        return DBManager.AddTrainer(trainer);
    }

    public Trainer SearchTrainer(String email, string password)
    {
        return DBManager.SearchTrainer(email, password);
    }
    public bool DeleteTrainer(int id)
    {
        return DBManager.DeleteTrainer(id);
    }
    public bool UpdateTrainer(Trainer trainer)
    {
        return DBManager.UpdateTrainer(trainer);
    }

}
