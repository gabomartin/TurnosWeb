IF(DB_ID(N'TurnosWebDB')) IS NULL

BEGIN

	PRINT N'Creating DB...'
	CREATE DATABASE [TurnosWebDB];

END

ELSE

BEGIN

	PRINT N'DB already exists.'

END
