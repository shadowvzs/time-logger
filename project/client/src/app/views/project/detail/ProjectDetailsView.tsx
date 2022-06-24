import React from "react";
import { observer } from "mobx-react-lite";
import {
    Button,
    Divider,
    LinearProgress,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography
} from "@mui/material";
import { Link, useNavigate, useParams } from "react-router-dom";

import { ProjectDetailsStore } from "./ProjectDetailsStore";
import { ProjectDetailHeader } from "./styles";
import { AppContext } from "../../../global/provider";
import { dateFormatter, minuteDurationFormatter } from "../../../utils/formatters";
import AddPopover from "../../../core/components/popovers/AddPopover";
import { NewLogForm } from "./forms/NewLogForm";

export const ProjectDetailsView = observer(() => {

    const { projectId } = useParams();
    const { container } = React.useContext(AppContext);
    const navigate = useNavigate();
    const store = React.useMemo(() => new ProjectDetailsStore(container, navigate, projectId!), [container, projectId, navigate]);

    return (
        <div>
            <ProjectDetailHeader>
                <Link to="/projects">
                    <Button variant='contained'>Back</Button>
                </Link>
                <Typography
                    variant='h5'
                    children={store.item?.name || 'Loading...'}
                    style={{ fontWeight: 'bold' }}
                />
                <AddPopover
                    Cmp={NewLogForm}
                    disabled={!store.item || store.item.isEnded || store.item.completed}
                    cmpProps={{
                        project: store.item,
                        onSubmit: store.addLog,
                    }}
                />

            </ProjectDetailHeader>
            <Divider />
            {!store.item && (<div><LinearProgress /></div>)}
            {store.item && (
                <TableContainer component={Paper} style={{ maxWidth: 400, margin: '32px auto' }}>
                    <Table sx={{ minWidth: 320 }} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Duration</TableCell>
                                <TableCell>Date</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {store.item.logs.map(log => (
                                <TableRow
                                    key={log.id}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell>{minuteDurationFormatter(log.loggedMinutes)}</TableCell>
                                    <TableCell>{dateFormatter(log.createdAt)}</TableCell>
                                </TableRow>
                            ))}
                            {!store.item.logs.length && (
                                <TableRow>
                                    <TableCell colSpan={2}>... empty ...</TableCell>
                                </TableRow>
                            )}
                        </TableBody>
                    </Table>
                </TableContainer>
            )}
        </div>
    );
});
