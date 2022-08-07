using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BeehiveManagementSystem
{
    public abstract class Bees : IWorker
    {        
        public Bees(string job)
        {
            Job = job;
        }
        public string Job { get; private set; }
        public abstract float CostPerShift { get; }

        protected abstract void DoJob();

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
        }


    }

    public class Queen : Bees,INotifyPropertyChanged
    {
        private float eggs=0;
        private float unassignedWorkers=3f;
        public string StatusReport { get; private set; }

        public const float EGGS_PER_SHIFT=0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private IWorker[] workers = new IWorker[0];

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Queen() : base("Queen")
        {

            AssignBee("Egg Care");
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");

        }

        public override float CostPerShift
        {
            get
            {
                return 2.15f;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
            }
            UpdateStatusReport();
        }

        private void AddWorker(IWorker worker)
        {

            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }

        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;

            foreach(var worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            
            if(eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }

        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach(IWorker worker in workers)
            {
                if (worker.Job == job) count++;
            }
            string s = "s";
            if(count == 1)
            {
                s = "";
            }
            return $"{count} {job} bee{s}";
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
                $"\nEgg count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
                $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" +
                $"\n{WorkerStatus("Egg Care")}\nTotal Workers: {workers.Length}";
            OnPropertyChanged("StatusReport");
        }

    }

    public class HoneyManufacturer : Bees
    {

        public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }

        public HoneyManufacturer() : base("Honey Manufacturer")
        {
        }

        public override float CostPerShift
        {
            get
            {
                return 1.7f;
            }
        }
    }

    public class NectarCollector : Bees
    {
        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }

        public NectarCollector() : base("Nectar Collector")
        {
        }

        public override float CostPerShift
        {
            get
            {
                return 1.95f;
            }
        }

    }

    public class EggCare : Bees
    {
        public Queen queen;
        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }

        public EggCare(Queen queen) : base("Egg Care")
        {
            this.queen = queen;
        }

        public override float CostPerShift
        {
            get
            {
                return 1.35f;
            }
        }

    }

}
