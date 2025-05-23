using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>(); // no metodo post, preciso transfomrar um dto para cinema para armazenar no db
        CreateMap<Cinema, ReadCinemaDto>(); // no metodo get, transformar um cinema para dto de read
        CreateMap<UpdateCinemaDto, Cinema>(); // no metodo update, preciso transformar o dto da atualização para cinema para poder armazenar no db
        CreateMap<Cinema, UpdateCinemaDto>(); // no metodo patch, preciso transformar o cinema para Dto, pois primeiro aplica o patch no dto e depois mapeia o dto para objeto
    }
}
