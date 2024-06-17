﻿using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;
//Map entities to dto
public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
         return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return  new(
                game.Id,
                game.Name,
                game.Genre!.Name, // gENRE NEVER BE NULL
                game.Price,
                game.ReleaseDate

            );
    }

      public static Game ToEntity(this UpdateGameDto game, int id)
    {
         return new Game()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
    }

        public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return  new(
                game.Id,
                game.Name,
                game.GenreId, // gENRE NEVER BE NULL
                game.Price,
                game.ReleaseDate

            );
    }

}
