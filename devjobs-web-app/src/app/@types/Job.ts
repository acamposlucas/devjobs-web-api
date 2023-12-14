import { Company } from "./Company"

export interface Job {
    id: number,
    company: Company,
    companyId: number,
    position: string,
    postedAt: Date,
    contractType: string,
    location: string,
    description: string,
    requirements: Requirements,
    requirementsId: number,
    role: Role,
    roleId: number
}

export interface JobSummary {
    id: number,
    company: string,
    postedAt: Date,
    position: string,
    contract: string,
    location: string,
    backgroundColor: string
}

interface Requirements {
    id: number,
    jobId: number,
    content: string,
    items: [
        {
            id: number,
            requirementsId: number,
            description: string
        }
    ]
}

interface Role {
    id: number,
    jobId: number,
    content: string,
    items: [
        {
            id: number,
            roleId: number,
            description: string
        }
    ]
}