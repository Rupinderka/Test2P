// Define the discriminated union for genres
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Define the Director record type
type Director = {
    Name: string
    Movies: int
}

// Define the Movie record type
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    ImdbRating: float
}

// Create movie instances according to the table
let coda = { 
    Name = "CODA"; 
    RunLength = 111; 
    Genre = Drama; 
    Director = { Name = "Sian Heder"; Movies = 9 }; 
    ImdbRating = 8.1 
}

let belfast = { 
    Name = "Belfast"; 
    RunLength = 98; 
    Genre = Comedy; 
    Director = { Name = "Kenneth Branagh"; Movies = 23 }; 
    ImdbRating = 7.3 
}

let dontLookUp = { 
    Name = "Don't Look Up"; 
    RunLength = 138; 
    Genre = Comedy; 
    Director = { Name = "Adam McKay"; Movies = 27 }; 
    ImdbRating = 7.2 
}

let driveMyCar = { 
    Name = "Drive My Car"; 
    RunLength = 179; 
    Genre = Drama; 
    Director = { Name = "Rysuke Hamaguchi"; Movies = 16 }; 
    ImdbRating = 7.6 
}

let dune = { 
    Name = "Dune"; 
    RunLength = 155; 
    Genre = Fantasy; 
    Director = { Name = "Denis Villeneuve"; Movies = 24 }; 
    ImdbRating = 8.1 
}

let kingRichard = { 
    Name = "King Richard"; 
    RunLength = 144; 
    Genre = Sport; 
    Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }; 
    ImdbRating = 7.5 
}

let licoricePizza = { 
    Name = "Licorice Pizza"; 
    RunLength = 133; 
    Genre = Comedy; 
    Director = { Name = "Paul Thomas Anderson"; Movies = 49 }; 
    ImdbRating = 7.4 
}

let nightmareAlley = { 
    Name = "Nightmare Alley"; 
    RunLength = 150; 
    Genre = Thriller; 
    Director = { Name = "Guillermo Del Toro"; Movies = 22 }; 
    ImdbRating = 7.1 
}

// Create a list of movies
let movies = [
    coda; belfast; dontLookUp; driveMyCar; dune; kingRichard; licoricePizza; nightmareAlley
]

// Identify probable Oscar winners (IMDB rating > 7.4)
let probableOscarWinners = 
    movies 
    |> List.filter (fun movie -> movie.ImdbRating > 7.4)

// Convert movie run length to hours and minutes
let runLengthToHoursMinutes runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

let runLengthInHoursMinutes = 
    movies 
    |> List.map (fun movie -> 
        sprintf "%s: %s" movie.Name (runLengthToHoursMinutes movie.RunLength)
    )

// Print results
printfn "Probable Oscar Winners:"
probableOscarWinners 
|> List.iter (fun movie -> printfn "%s (Rating: %.1f)" movie.Name movie.ImdbRating)

printfn "\nMovie Run Length in Hours and Minutes:"
runLengthInHoursMinutes 
|> List.iter (fun result -> printfn "%s" result)
