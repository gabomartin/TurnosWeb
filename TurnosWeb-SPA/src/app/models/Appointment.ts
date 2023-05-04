import { ServiceViewModel } from "./ServiceViewModel";

export interface AppointmentViewModel {
appointmentId: number,
clientName: string,
barberName: number,
state: number,
appointmentDate: string,
totalCharged: number,
services: [ServiceViewModel]
}
