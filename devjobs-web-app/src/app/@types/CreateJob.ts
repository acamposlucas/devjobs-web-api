export interface CreateJob {
    companyId: string,
    position: string,
    contractType: string,
    location: string,
    description: string,
    requirements: { value: string }[],
    roles: { value: string }[]
}
