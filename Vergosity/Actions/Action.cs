#region

using System;
using System.Collections.Generic;
using Vergosity.Validation;

#endregion

namespace Vergosity.Actions
{
	/// <summary>
	///   A base framework class for business actions.
	/// </summary>
	public abstract class Action : IAction
	{
		#region Fields;

		private readonly Guid transactionId = Guid.NewGuid();
		private bool allowExecution = true;
		private bool isAuthorized = true;
		private ActionResult result = ActionResult.Unknown;
		private ActionState state = ActionState.NotExecuted;
		private List<string> roles = new List<string>();

		#endregion

		#region Events Handlers;

		/// <summary>
		///   Occurs when [on action result validated].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnActionResultValidated;

		/// <summary>
		///   Occurs when [on action result validating].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnActionResultValidating;

		/// <summary>
		///   Occurs when [on action started].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnActionStarted;

		/// <summary>
		///   Occurs when [on action starting].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnActionStarting;

		/// <summary>
		///   Occurs when [on audited].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnAudited;

		/// <summary>
		///   Occurs when [on auditing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnAuditing;

		/// <summary>
		///   Occurs when [on authorized].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnAuthorized;

		/// <summary>
		///   Occurs when [on authorizing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnAuthorizing;

		/// <summary>
		///   Occurs when [on executed].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnExecuted;

		/// <summary>
		///   Occurs when [on executing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnExecuting;

		/// <summary>
		///   Occurs when [on post action ended].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostActionEnded;

		/// <summary>
		///   Occurs when [on post action executed].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostActionExecuted;

		/// <summary>
		///   Occurs when [on post action executing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostActionExecuting;

		/// <summary>
		///   Occurs when [on post authorized].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostAuthorized;

		/// <summary>
		///   Occurs when [on post authorizing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostAuthorizing;

		/// <summary>
		///   Occurs when [on post validated].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostValidated;

		/// <summary>
		///   Occurs when [on post validating].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPostValidating;

		/// <summary>
		///   Occurs when [on pre action ending].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreActionEnding;

		/// <summary>
		///   Occurs when [on pre action executed].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreActionExecuted;

		/// <summary>
		///   Occurs when [on pre action executing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreActionExecuting;

		/// <summary>
		///   Occurs when [on pre audited].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreAudited;

		/// <summary>
		///   Occurs when [on pre auditing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreAuditing;

		/// <summary>
		///   Occurs when [on pre authorized].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreAuthorized;

		/// <summary>
		///   Occurs when [on pre authorizing].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreAuthorizing;

		/// <summary>
		///   Occurs when [on pre validated].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreValidated;

		/// <summary>
		///   Occurs when [on pre validating].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnPreValidating;

		/// <summary>
		///   Occurs when [on validated].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnValidated;

		/// <summary>
		///   Occurs when [on validating].
		/// </summary>
		public event EventHandler<ProcessActionEventArgs> OnValidating;

		#endregion

		#region Processing Method(s);

		/// <summary>
		///   This <see cref="bool" /> property indicates the execution status of the action. This property must be set to true in order for the action to be executed. Use
		/// </summary>
		public virtual bool AllowExecution
		{
			get
			{
				return allowExecution;
			}
			set
			{
				allowExecution = value;
			}
		}

		/// <summary>
		///   Gets or sets a value indicating whether this instance is authorized.
		/// </summary>
		/// <value> <c>true</c> if this instance is authorized; otherwise, <c>false</c> . </value>
		public bool IsAuthorized
		{
			get
			{
				return isAuthorized;
			}
			set
			{
				isAuthorized = value;
			}
		}

		/// <summary>
		///   Use to set/get the <see cref="ActionResult" /> for the action.
		/// </summary>
		public ActionResult Result
		{
			get
			{
				return result;
			}
			set
			{
				result = value;
			}
		}

		/// <summary>
		///   Gets or sets the state.
		/// </summary>
		/// <value> The state. </value>
		public ActionState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
			}
		}

		/// <summary>
		///   A unique identifier for the current action. Used to group any logging, events, or KPI logging activity.
		/// </summary>
		public Guid TransactionId
		{
			get
			{
				return transactionId;
			}
		}

		/// <summary>
		/// Class implementors must override and implement this <see cref="ValidationContext"/> property. <see cref="ValidationContext"/> is an abstract class, therefore, a sub-class that implements the abstract class will be needed.
		/// </summary>
		/// <value>
		/// The validation context.
		/// </value>
		public virtual IValidationContext ValidationContext{ get; set; }

		/// <summary>
		/// Gets the roles associated to the action.
		/// </summary>
		/// <value>
		/// The roles.
		/// </value>
		public List<string> Roles
		{
			get
			{
				return roles;
			}
			set
			{
				this.roles = value;
			}
		}

		/// <summary>
		///   Use to process the action. This method processes the entire lifecycle of the action. It include pre and post process items. The action lifecycle as well as the also includes calls to execute and validate the action.
		/// </summary>
		public void Execute()
		{
			state = ActionState.InProcess;
			StartAction();

			// Uses optimistic authorization; Evaluates to false if explicitly set to false during Authorize() call;
			if (this.allowExecution && this.isAuthorized)
			{
				ProcessAction();
			}

			FinishAction();
			state = ActionState.Complete;
		}

		/// <summary>
		/// Does this instance.
		/// </summary>
		public virtual void PerformAction()
		{
			;
		}

		/// <summary>
		///   Override this method to implement auditing of the action. The audit information should be persisted to an audit log.
		/// </summary>
		protected virtual void Audit()
		{
			;
		}

		/// <summary>
		///   Override this method to provide an authorization mechanism for the action. A typical override will determine if the current user has permission to perform the action.
		/// </summary>
		protected virtual void Authorize()
		{
			;
		}

		/// <summary>
		///   Evaluates the rules.
		/// </summary>
		protected virtual void EvaluateRules()
		{
			if (this.isAuthorized)
			{
				OnValidateAction(new ProcessActionEventArgs(allowExecution));
				IValidationContext context = ValidateAction();
				if(!context.IsValid)
				{
					allowExecution = false;
					result = ActionResult.Fail;
					context.State = ValidationContextState.Success;
				}
				else
				{
					result = ActionResult.Success;
					allowExecution = true;
					context.State = ValidationContextState.Failure;
				}

				OnValidateActionComplete(new ProcessActionEventArgs(allowExecution));
			}
		}

		/// <summary>
		///   Override this method to provide a final method that completes the processing of the action. Usage could include resource management and other housekeeping that might be seperated from the business logic.
		/// </summary>
		protected virtual void Finish()
		{
			;
		}

		/// <summary>
		///   Use to publish the <see cref="OnActionResultValidated" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnActionResultValidateComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnActionResultValidated;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnActionResultValidating" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnActionResultValidateStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnActionResultValidating;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish <see cref="OnAuditing" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnAudit(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnAuditing;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish the <see cref="OnAudited" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnAuditComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnAudited;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish the <see cref="OnAuthorizing" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnAuthorize(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnAuthorizing;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish the <see cref="OnAuthorized" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnAuthorizeComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnAuthorized;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnExecuting" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnExecute(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnExecuting;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnExecuted" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnExecuteComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnExecuted;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPostActionExecuted" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPostActionExecuteComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPostActionExecuted;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPostActionExecuting" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPostActionExecuteStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> hanlder = OnPostActionExecuting;
			if (hanlder != null)
			{
				hanlder(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPostAuthorized" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPostAuthorizeComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPostAuthorized;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPostAuthorizing" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPostAuthorizeStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPostAuthorizing;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPostValidated" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPostValidateActionComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPostValidated;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPostValidating" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPostValidateActionStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPostValidating;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish the <see cref="OnPostActionEnded" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreActionEndComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPostActionEnded;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish the <see cref="OnPreActionEnding" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreActionEndingStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreActionEnding;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPreActionExecuted" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreActionExecuteComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> hanlder = OnPreActionExecuted;
			if (hanlder != null)
			{
				hanlder(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPreActionExecuting" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreActionExecuteStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> hanlder = OnPreActionExecuting;
			if (hanlder != null)
			{
				hanlder(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPreAudited" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreAuditComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreAudited;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPreAuditing" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreAuditStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreAuditing;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish <see cref="OnPreAuthorized" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreAuthorizeComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreAuthorized;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish <see cref="OnPreAuthorizing" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreAuthorizeStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreAuthorizing;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPreValidated" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreValidateActionComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreValidated;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnPreValidating" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnPreValidateActionStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnPreValidating;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish <see cref="OnActionStarting" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnStart(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnActionStarting;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish <see cref="OnActionStarted" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnStartComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnActionStarted;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnValidating" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnValidateAction(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnValidating;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Use to publish an <see cref="OnValidated" /> event.
		/// </summary>
		/// <param name="e"> </param>
		protected virtual void OnValidateActionComplete(ProcessActionEventArgs e)
		{
			EventHandler<ProcessActionEventArgs> handler = OnValidated;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		///   Override and implement this method to perform an operation after the <see cref="Authorize" /> is complete.
		/// </summary>
		protected virtual void PostAuthorize()
		{
			;
		}

		/// <summary>
		///   Override and implement this method to perform an operation that occurs after the <see cref="PerformAction" /> is complete.
		/// </summary>
		protected virtual void PostExecuteAction()
		{
			;
		}

		/// <summary>
		///   Override and implement this method to perform an operation that occurs after the <see cref="ValidateAction" /> is complete.
		/// </summary>
		protected virtual void PostValidateAction()
		{
			;
		}

		/// <summary>
		///   Override and implement this method to perform an operation that occurs before the <see cref="Authorize" /> .
		/// </summary>
		protected virtual void PreAuthorize()
		{
			;
		}

		/// <summary>
		///   Override and implement this method to perform an operation that occurs before the <see cref="PerformAction" /> call.
		/// </summary>
		protected virtual void PreExecuteAction()
		{
			;
		}

		/// <summary>
		///   Override and implement this method to perform an operation that occurs before the <see cref="ValidateAction" /> call.
		/// </summary>
		protected virtual void PreValidateAction()
		{
			;
		}

		/// <summary>
		///   Override and implement this method to perform an operation that occurs at the beginning of the action processing.
		/// </summary>
		protected virtual void Start()
		{
			;
		}

		/// <summary>
		/// Use this method to validate the action. Validation may include any business rules, required data, and specific data formats.
		/// </summary>
		/// <returns></returns>
		protected virtual IValidationContext ValidateAction()
		{
			return this.ValidationContext;
		}

		/// <summary>
		/// Use to validate the resultDetails of the action. The implementation may include any event or KPI logging.
		/// </summary>
		/// <returns></returns>
		protected virtual ActionResult ValidateActionResult()
		{
			return this.Result;
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		private void Initialize()
		{
			;
		}

		/// <summary>
		/// Initializes the roles from the action attribute declaration. See <see cref="ActionRolesAttribute"/>
		/// for more information. 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		protected virtual List<string> InitializeRoles(Action action)
		{
			// retrieve default roles for action using declarative attributes; 
			Type actionType = action.GetType();
			{
				List<object> roleAttributes = new List<object>(actionType.GetCustomAttributes(typeof (ActionRolesAttribute), true));
				if (roleAttributes.Count > 0)
				{
					foreach (object roleAttribute in roleAttributes)
						this.roles = ((ActionRolesAttribute)roleAttribute).Roles;
				}
			}
			return this.roles;
		}

		/// <summary>
		///   Use to perform the post-process items of the action lifecycle. It will runs the pipeline methods: <see
		///    cref="ValidateActionResult" /> and <see cref="Finish" /> .
		/// </summary>
		private void FinishAction()
		{
			OnPostActionExecuteStart(new ProcessActionEventArgs(AllowExecution));
			PostExecuteAction();
			OnPostActionExecuteComplete(new ProcessActionEventArgs(AllowExecution));

			OnActionResultValidateStart(new ProcessActionEventArgs(AllowExecution));
			ValidateActionResult();
			OnActionResultValidateComplete(new ProcessActionEventArgs(AllowExecution));

			OnPreActionEndingStart(new ProcessActionEventArgs(AllowExecution));
			Finish();
			OnPreActionEndComplete(new ProcessActionEventArgs(AllowExecution));
		}

		/// <summary>
		///   Used to perform operations related to the execution of the action;
		/// </summary>
		private void ProcessAction()
		{
			OnExecute(new ProcessActionEventArgs(AllowExecution));
			PerformAction();
			OnExecuteComplete(new ProcessActionEventArgs(AllowExecution));
		}

		/// <summary>
		///   Used to perform the pre-process items of the action lifecycle. It includes calls to audit and validate the action.
		/// </summary>
		private void StartAction()
		{
			Initialize(); //loading and initialization of action.

			// Use to perform any operations during the Start of the action processing.
			OnStart(new ProcessActionEventArgs(AllowExecution));
			Start();
			OnStartComplete(new ProcessActionEventArgs(AllowExecution));

			// Use to implement any pre-Authorization operations;
			OnPreAuthorizeStart(new ProcessActionEventArgs(AllowExecution));
			PreAuthorize();
			OnPreAuthorizeComplete(new ProcessActionEventArgs(AllowExecution));

			// Used to authorize the request against the permissions or business rules;
			OnAuthorize(new ProcessActionEventArgs(AllowExecution));
			Authorize();
			OnAuthorizeComplete(new ProcessActionEventArgs(AllowExecution));

			// Use to implement an post-Authorizing operations.
			OnPostAuthorizeStart(new ProcessActionEventArgs(AllowExecution));
			PostAuthorize();
			OnPostAuthorizeComplete(new ProcessActionEventArgs(AllowExecution));

			// Use for auditing and logging information for the request.
			OnAudit(new ProcessActionEventArgs(AllowExecution));
			Audit();
			OnAuditComplete(new ProcessActionEventArgs(AllowExecution));

			// Use to implement any pre-validation operations;
			OnPreValidateActionStart(new ProcessActionEventArgs(AllowExecution));
			PreValidateAction();
			OnPreValidateActionComplete(new ProcessActionEventArgs(AllowExecution));

			// Used for validation logic and validation business rules.
			OnValidateAction(new ProcessActionEventArgs(AllowExecution));
			EvaluateRules();
			OnValidateActionComplete(new ProcessActionEventArgs(AllowExecution));

			// Use to perform any operations post-Validation;
			OnPostValidateActionStart(new ProcessActionEventArgs(allowExecution));
			PostValidateAction();
			OnPostValidateActionComplete(new ProcessActionEventArgs(allowExecution));

			// Use to perform operations and to determine if the action is allowed to be executed.
			OnPreActionExecuteStart(new ProcessActionEventArgs(AllowExecution));
			PreExecuteAction();
			OnPreActionExecuteComplete(new ProcessActionEventArgs(AllowExecution));
		}

		#endregion
	}
}