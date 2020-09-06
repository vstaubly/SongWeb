This project provides a web interface for browsing (and eventually possibly editing)
the song database created and populated by the SongIndexer program (separate repo).
Currently, the code assumes a DSN of "SongsDB", but the aim is to make that configurable
without needing to recompile.

The project assumes the following schema for the DB (and copes with any of the fields containing nulls):

CREATE TABLE songs ( id INTEGER PRIMARY KEY, title TEXT, artist TEXT, album TEXT, year TEXT, track TEXT );

Next plans are to allow searching on any of the fields, and sorting by any field.
