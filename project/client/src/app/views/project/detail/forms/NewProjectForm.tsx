import React from "react";
import {
    Button,
    FormControl,
    Grid,
    InputLabel,
    MenuItem,
    Select,
    SelectChangeEvent,
    TextField,
    Typography
} from "@mui/material";

import { action, makeObservable, observable, toJS } from "mobx";
import { observer } from "mobx-react-lite";
import { ICompany } from "../../../../model/Company";
import { IProject } from "../../../../model/Project";
import { guid } from "../../../../utils/guid";

interface NewProjectFormProps {
    companies: ICompany[],
    onClose: () => void;
    onSubmit: (project: IProject) => void;
}

class NewProjectFormStore {
    public project: IProject = {
        id: guid(),
        name: '',
        completed: false,
        companyId: '',
        deadline: new Date(Date.now() + 1000 * 60 * 60 * 24 * 14).toISOString(),
    };

    public setProjectData(field: keyof IProject, value: any) { this.project = { ...this.project, [field]: value }; }

    constructor(private _props: NewProjectFormProps) {
        makeObservable(this, {
            project: observable,
            setProjectData: action.bound,
        })
        this.project.companyId = _props.companies[0]?.id || '';
    }

    public onSelectCompany = (ev: SelectChangeEvent<string>) => {
        this.setProjectData('companyId', ev.target.value);
    }

    public onChangeHandler = (ev: React.ChangeEvent<HTMLInputElement>) => {
        const { value, name } = ev.currentTarget;
        this.setProjectData(name as keyof IProject, value.replace(/[|&;$%@"<>()+,]/g, ''));
    }

    public onSave = () => {
        const { onClose, onSubmit } = this._props;
        const raw = toJS(this.project);
        onSubmit(raw);
        onClose();
    }
}

export const NewProjectForm = observer((props: NewProjectFormProps) => {
    const store = React.useMemo(() => new NewProjectFormStore(props), [props])

    return (
        <Grid container direction='column' spacing={1} style={{ padding: 8 }}>
            <Grid item>
                <Typography variant='h6' children='Add Project' style={{ paddingBottom: 6, textAlign: 'center' }} />
            </Grid>
            <Grid item>
                <TextField
                    style={{ maxWidth: 240 }}
                    label='Project Name'
                    variant='outlined'
                    size='small'
                    type='text'
                    name='name'
                    value={store.project.name}
                    onChange={store.onChangeHandler}
                />
            </Grid>
            <Grid item>
                <FormControl fullWidth size='small'>
                    <InputLabel id='company-select-label'>Company</InputLabel>
                    <Select
                        labelId='company-select-label'
                        value={store.project.companyId}
                        label='Company'
                        onChange={store.onSelectCompany}
                        style={{ minWidth: 200 }}
                    >
                        {props.companies.map(c => (
                            <MenuItem value={c.id} key={c.id}>{c.name}</MenuItem>
                        ))}
                    </Select>
                </FormControl>
            </Grid>
            <Grid item>
                <Grid container justifyContent='space-around'>
                    <Button variant='contained' color='info' onClick={props.onClose}>
                        Cancel
                    </Button>
                    <Button
                        variant='contained'
                        color='primary'
                        onClick={store.onSave}
                        disabled={!store.project.name.length || !store.project.companyId}
                    >
                        Save
                    </Button>
                </Grid>
            </Grid>
        </Grid>
    );
});