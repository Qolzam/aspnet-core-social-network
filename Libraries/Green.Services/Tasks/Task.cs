using System;
using Green.Core.Domain.Tasks;
using Green.Core.Infrastructure;

namespace Green.Services.Tasks
{
    /// <summary>
    /// Task
    /// </summary>
    public partial class Task
    {
        #region Ctor

        /// <summary>
        /// Ctor for Task
        /// </summary>
        private Task()
        {
            this.Enabled = true;
        }

        /// <summary>
        /// Ctor for Task
        /// </summary>
        /// <param name="task">Task </param>
        public Task(ScheduleTask task)
        {
            this.Type = task.Type;
            this.Enabled = task.Enabled;
            this.StopOnError = task.StopOnError;
            this.Name = task.Name;
            this.LastSuccessUtc = task.LastSuccessUtc;
        }

        #endregion

        #region Utilities

        private ITask CreateTask()
        {
            if (!this.Enabled)
                return null;

            var type = System.Type.GetType(this.Type);
            if (type == null)
                return null;

            object instance = null;
            try
            {
                instance = EngineContext.Current.Resolve(type);
            }
            catch
            {
                //try resolve
            }
            if (instance == null)
            {
                //not resolved
                instance = EngineContext.Current.ResolveUnregistered(type);
            }

            return instance as ITask;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the task
        /// </summary>
        /// <param name="throwException">A value indicating whether exception should be thrown if some error happens</param>
         public void Execute(bool throwException = false)
        {
            var scheduleTaskService = EngineContext.Current.Resolve<IScheduleTaskService>();
            var scheduleTask = scheduleTaskService.GetTaskByType(this.Type);

            try
            {
                //flag that task is already executed
                var taskExecuted = false;

                //execute task in case if is not executed yet
                if (!taskExecuted)
                {
                    //initialize and execute
                    var task = this.CreateTask();
                    if (task != null)
                    {
                        this.LastStartUtc = DateTime.UtcNow;
                        if (scheduleTask != null)
                        {
                            //update appropriate datetime properties
                            scheduleTask.LastStartUtc = this.LastStartUtc;
                            scheduleTaskService.UpdateTask(scheduleTask);
                        }
                        task.Execute();
                        this.LastEndUtc = this.LastSuccessUtc = DateTime.UtcNow;
                    }
                }
            }
            catch (Exception)
            {
                this.Enabled = !this.StopOnError;
                this.LastEndUtc = DateTime.UtcNow;

                   if (throwException)
                    throw;
            }

            if (scheduleTask != null)
            {
                //update appropriate datetime properties
                scheduleTask.LastEndUtc = this.LastEndUtc;
                scheduleTask.LastSuccessUtc = this.LastSuccessUtc;
                scheduleTaskService.UpdateTask(scheduleTask);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Datetime of the last start
        /// </summary>
        public DateTime? LastStartUtc { get; private set; }

        /// <summary>
        /// Datetime of the last end
        /// </summary>
        public DateTime? LastEndUtc { get; private set; }

        /// <summary>
        /// Datetime of the last success
        /// </summary>
        public DateTime? LastSuccessUtc { get; private set; }

        /// <summary>
        /// A value indicating type of the task
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// A value indicating whether to stop task on error
        /// </summary>
        public bool StopOnError { get; private set; }

        /// <summary>
        /// Get the task name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A value indicating whether the task is enabled
        /// </summary>
        public bool Enabled { get; set; }

        #endregion
    }
}
