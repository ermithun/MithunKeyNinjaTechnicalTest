import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink, BrowserRouter as Router, Route } from 'react-router-dom';


interface RiderState {
    riders: AverageRiderReview[];
    loading: boolean;
}

export class AverageRiderReviewList extends React.Component<RouteComponentProps<{}>, RiderState> {
    constructor(props) {
        super(props);
        this.state = { riders: [], loading: true };
        fetch('api/Rider/AverageReview')
            .then(response => response.json() as Promise<AverageRiderReview[]>)
            .then(data => {
                this.setState({ riders: data, loading: false });
            });
    }



    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderRiderList(this.state.riders);

        return <div>
            <h1>Rider</h1>
            {contents}
        </div>;
    }


    private renderRiderList(riders: AverageRiderReview[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>FIRST NAME</th>
                    <th>LAST NAME</th>
                    <th>PHONE NUMBER</th>
                    <th>EMAIL </th>
                    <th>START DATE</th>
                    <th>AVERAGE REVIEW</th>
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
                        <td>{}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class AverageRiderReview {
    firstName: string = "";
    lastName: string = "";
    phoneNumber: string = "";
    email: string = "";
    startDate: string = "";
    averageReview:number=0;
}
