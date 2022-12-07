namespace SmartPark.Domain.Enums;
public enum DoorAction : byte
{
    NoAction = 0,
    GrantAccess = 1,
    Reject = 2,
    SaveAsTrustedVehicle = 3,
}