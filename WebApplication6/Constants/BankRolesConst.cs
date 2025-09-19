public enum bankRoleEnums { Client , Admin = -1 };

public enum accountRoles {add = 1 , filter = 2 , update = 4 , delete = 8 , getDashboardAccounts = 2048}
public enum transferRoles { add = 16 , filter = 32 , getNumberOfTransfers = 512 , getRecentActivity = 4096 , getTransactions = 8192}
public enum usersRoles { filter = 64 , update = 128 , delete =256 , getTotalBalance = 1024 , getUserById = 16384}