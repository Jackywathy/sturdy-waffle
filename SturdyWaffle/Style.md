# Capitalisation:
- `PascalCase` for *public* class variables, types and namespaces. "IOStream", "MoneyAmount"
- `CamelCase` for parameter names

# General
- The default modifer should be `private`. This is to help the ide choose which functions are revelant.


# Databases
AccountDatabase
	Table: Credentials
	- AccountNumber
	- FirstName, MiddleName, Lastname
	- Date of birth

	Table: Cards
	- Card Number
	- CVV
	- Account Number
	- Account Type