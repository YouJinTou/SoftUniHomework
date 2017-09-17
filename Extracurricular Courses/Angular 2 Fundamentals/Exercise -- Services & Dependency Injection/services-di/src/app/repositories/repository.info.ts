import { ContributorInfo } from './contributor.info';

export class RepositoryInfo {
    name: string;
    language: string;
    stargazers_count: number;
    svn_url: string;
    contributorsInfo: ContributorInfo[]
}