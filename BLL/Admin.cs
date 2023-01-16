using DAL.Connected;
using BOL;

namespace BLL;


public class Admin
{
    public List<Trainer> GetAllTrainers(){
        List<Trainer> allTrainers = new List<Trainer>();
        allTrainers=DBManager.GetAllTrainers();
        return allTrainers; 
    }

    public bool AddTrainer(Trainer trainer){
        return DBManager.AddTrainer(trainer);
    }
}
