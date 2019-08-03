import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink, BrowserRouter as Router, Route } from 'react-router-dom';


interface RiderState {
    riders: RiderReview[];
    loading: boolean;
}

export class RiderReviewList extends React.Component<RouteComponentProps<{}>, RiderState> {
    constructor(props) {
        super(props);
        this.state = { riders: [], loading: true };
        fetch('api/Rider/RiderReview')
            .then(response => response.json() as Promise<RiderReview[]>)
            .then(data => {
                this.setState({ riders: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderRiderReviewList(this.state.riders);

        return <div>
            <h1>Rider Review</h1>
            {contents}
        </div>;
    }


    private renderRiderReviewList(riders: RiderReview[]) {
        return <table className='table table-resposive'>
            <thead>
                <tr>
                    <th>FIRST NAME</th>
                    <th>LAST NAME</th>
                    <th>PHONE NUMBER</th>
                    <th>EMAIL </th>
                    <th>START DATE</th>
                    <th>AVERAGE REVIEW</th>
                    <th>BEST REVIEW</th>
                    <th>BEST COMMENT</th>
                </tr>
            </thead>
            <tbody>
                {riders.map(x =>
                    <tr>
                        <td>{x.firstName}</td>
                        <td>{x.lastName}</td>
                        <td>{x.phoneNumber}</td>
                        <td>{x.email}</td>
                        <td>{x.startDate}</td>
                        <td>{x.averageReviewScore}</td>
                        <td>{x.bestReviewScore}</td>
                        <td>{x.bestReviewComments}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class RiderReview {
    firstName: string = "";
    lastName: string = "";
    phoneNumber: string = "";
    email: string = "";
    startDate: string = "";
    averageReviewScore: number = 0;
    bestReviewScore: number = 0;
    bestReviewComments: string = "";
}
