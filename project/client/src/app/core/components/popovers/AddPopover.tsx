import * as React from 'react';
import Popover from '@mui/material/Popover';
import Button from '@mui/material/Button';

interface AddPopoverProps<P> {
    label?: string;
    disabled?: boolean;
    Cmp: (props: P & { onClose: () => void }) => JSX.Element;
    cmpProps: P;
}

export default function AddPopover<P>(props: AddPopoverProps<P>) {
    const { cmpProps, Cmp, disabled, label = 'Add' } = props;
    const [anchorEl, setAnchorEl] = React.useState<HTMLButtonElement | null>(null);

    const onClose = React.useCallback(() => { setAnchorEl(null); }, [setAnchorEl]);
    const onOpen = React.useCallback((event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    }, [setAnchorEl]);

    const open = Boolean(anchorEl);
    const id = open ? 'add-popover' : undefined;

    return (
        <div>
            <Button aria-describedby={id} variant="contained" onClick={onOpen} disabled={disabled}>
                {label}
            </Button>
            <Popover
                id={id}
                open={open}
                anchorEl={anchorEl}
                onClose={onClose}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'left',
                }}
            >
                <div style={{ padding: 8 }}>
                    <Cmp {...cmpProps} onClose={onClose} />
                </div>
            </Popover>
        </div>
    );
}