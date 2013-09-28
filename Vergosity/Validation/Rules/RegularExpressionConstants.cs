namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   A set of common regular expression constants.
	/// </summary>
	public class RegularExpressionConstants
	{
		/// <summary>
		///   Validates an American Express credit card number.
		/// </summary>
		public const string AmericanExpressCardNumber = @"^3[4,7]\d{2}-?\s?\d{4}-?\s?\d{4}-?\s?\d{3}$";

		/// <summary>
		///   Validates a Diners Club credit card number.
		/// </summary>
		public const string DinersClubCardNumber = @"^3[0,6,8]\d{2}-?\s?\d{4}-?\s?\d{4}-?\s?\d{2}$";

		/// <summary>
		///   Validates a Discover credit card number.
		/// </summary>
		public const string DiscoverCardNumber = @"^6011-?\s?\d{4}-?\s?\d{4}-?\s?\d{4}$";

		/// <summary>
		///   Validates an e-mail address. Ex. someone@example.com
		/// </summary>
		public const string Email = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

		/// <summary>
		///   Validates a MasterCard credit card number.
		/// </summary>
		public const string MasterCardCardNumber = @"^5[1-5]\d{2}-?\s?\d{4}-?\s?\d{4}-?\s?\d{4}$";

		/// <summary>
		///   Validates a name. Allows up to 30 uppercase and lowercase characters and a few special characters that are common to some names.
		/// </summary>
		public const string Name = @"^[a-zA-Z'-., ]{1,30}$";

		/// <summary>
		///   Validates that the field contains an integer greater than zero.
		/// </summary>
		public const string NonNegativeInteger = @"^\d+$";

		/// <summary>
		///   Validates password. It must be at least seven characters long, and should include at least one alpha and one numeric character.
		/// </summary>
		public const string Password = @"^.*(?=.{7,})(?=.*\d)(?=.*[a-zA-Z]).*$";

		/// <summary>
		///   Validates a phone number is 7 characters long.
		/// </summary>
		public const string PhoneNumber = @".{7}.*";

		/// <summary>
		///   Validates a positive currency amount. If there is a decimal point, it requires 2 numeric characters after the decimal point.
		/// </summary>
		public const string PositiveCurrency = @"^\d+(\.\d\d)?$";

		/// <summary>
		///   Validates a U.S. Social Security Number. The input must consist of 3 numeric characters followed by a dash, then 2 numeric characters followed by a dash, and then 4 numeric characters.
		/// </summary>
		public const string SocialSecurityNumber = @"^\d{3}-\d{2}-\d{4}$";

		/// <summary>
		///   Validates a fully qualified URL.
		/// </summary>
		public const string URL = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

		/// <summary>
		///   A regular express to validate a two-character value for US states.
		/// </summary>
		public const string US_State = @"^(A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[ANU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";

		/// <summary>
		///   Validates a Visa credit card number.
		/// </summary>
		public const string VisaCardNumber = @"^4\d{3}-?\s?\d{4}-?\s?\d{4}-?\s?\d{4}$";

		/// <summary>
		///   Validates a U.S. ZIP Code. The code must consist of 5 or 9 numeric characters.
		/// </summary>
		public const string ZipCode = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";
	}
}