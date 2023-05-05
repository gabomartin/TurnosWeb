import { ServiceViewModel } from "./ServiceViewModel";

export interface AppointmentViewModel {
appointmentId: number,
clientName: string,
barberName: string,
state: string,
appointmentDate: string,
totalCharged: number,
services: ServiceViewModel[]
}
