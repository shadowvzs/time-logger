import styled from "@emotion/styled";
import { Grid } from "@mui/material";

export const StyledTitleCell = styled(Grid)`
    display: flex;
    flex-wrap: no-wrap;
    justify-content: center;
    align-items: center;
    & p {
        font-weight: 600;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
    }
    & .sort-icon {
        opacity: 0;
        &.active {
            cursor: pointer;
            opacity: 0.85;
        }
    }
    &:hover .sort-icon:not(.active) {
        opacity: 0.35;
        cursor: pointer;
    }
`;
