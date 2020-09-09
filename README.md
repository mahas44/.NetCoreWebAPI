# .NetCoreWebAPI

Generic Repository Design (using MongoDB)

You can import test data in mongo like this

mongoimport --db DBName --collection CollectionName --type json --file test-movies.json --jsonArray

mongoimport --db DBName --collection CollectionName --type json --file test-series.json --jsonArray

Note: Make sure mongo service is running (on Ubuntu/Debian => sudo service mongod start)

Some url exp.

"localhost:xxxx/api/series"

"localhost:xxxx/api/series/45"

"localhost:xxxx/api/series/search?name=gear"

"localhost:xxxx/api/movies/discover?date=25-10-1999"  => return all movies if release_date grater than this date(dd-mm-yyyy)

