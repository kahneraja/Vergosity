using System;
using Vergosity.Actions;
using Vergosity.Validation.Attributes;

namespace Vergosity.Framework.Tests.Validation
{
    [ActionTest("ActionIsValid", "The action is not valid. Cannot execute process.")]
    internal class TestAction : ActionBase
    {
        private readonly DateTime currentDateTime;
        [StringIsNotNullEmptyRange("StringLengthIsValid", "The string length is not valid; valid range is 8-20.", 8, 20)] 
        private readonly string name;
        private string answer;
        [MinValue("NumberMinValue", "The number is not valid. Minimum value is 10.", 10)] 
        private int number = 1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TestAction" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="currentDateTime">The current date time.</param>
        public TestAction(string name, DateTime currentDateTime)
        {
            this.name = name;
            this.currentDateTime = currentDateTime;
        }

        /// <summary>
        ///     Gets the answer. The return object of the action.
        /// </summary>
        /// <value>
        ///     The answer.
        /// </value>
        public string Answer
        {
            get { return answer; }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        ///     Gets the current date time.
        /// </summary>
        /// <value>
        ///     The current date time.
        /// </value>
        public DateTime CurrentDateTime
        {
            get { return currentDateTime; }
        }

        /// <summary>
        ///     Does this instance.
        /// </summary>
        public override void PerformAction()
        {
            base.PerformAction();
            answer = Name + "; " + CurrentDateTime.ToLongDateString();
        }

        /// <summary>
        ///     Use to validate the resultDetails of the action. The implementation may include any event or KPI logging.
        /// </summary>
        /// <returns></returns>
        protected override ActionResult ValidateActionResult()
        {
            Result = !string.IsNullOrEmpty(answer) ? ActionResult.Success : ActionResult.Fail;
            return Result;
        }
    }
}