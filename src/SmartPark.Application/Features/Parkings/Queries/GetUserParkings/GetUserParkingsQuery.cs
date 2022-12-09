using MediatR;
using SmartPark.Application.Features.Parkings.Models;

namespace SmartPark.Application.Features.Parkings.Queries.GetUserParkings;
public class GetUserParkingsQuery : IRequest<IList<ParkingViewModel>>
{
}