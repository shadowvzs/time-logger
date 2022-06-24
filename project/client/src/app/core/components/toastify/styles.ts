import styled from "@emotion/styled";

export const StyledToastContainer = styled('div')(({
    position: 'fixed',
    top: 0,
    right: 0,
    margin: '0 4px',
    minWidth: 200,
    maxWidth: 400,
    height: 'auto',
    overflowY: 'auto',
    overflowX: 'hidden',
    zIndex: 9999,
    width: 300,
    '& .notify': {
        position: 'relative',
        color: '#fff',
        border: '1px solid rgba(0, 0, 0, 0.3)',
        borderRadius: 4,
        padding: 15,
        paddingRight: 20,
        width: 'auto',
        maxWidth: 400,
        height: 'auto',
        opacity: 1,
        margin: '3px 0 3px 3px',
        transform: 'translateX(100%)',
        fontFamily: 'arial',
        fontSize: 14,
        transition: 'transform 0.72s',
        boxShadow: '0px 0 2px 2px rgba(0, 0, 0, 0.2)',
        '&.warning': {
            borderColor: 'rgba(255, 255, 0, 0.9)',
            backgroundColor: 'rgba(255, 255, 0, 0.5)'
        },
        '&.notice': {
            borderColor: 'rgba(0, 0, 200, 0.9)',
            backgroundColor: 'rgba(0, 0, 200, 0.5)'
        },       
        '&.success': {
            borderColor: 'rgba(100, 100, 255, 0.9)',
            backgroundColor: 'rgba(100, 100, 255, 0.5)'
        },        
        '&.error': {
            borderColor: 'rgba(255, 50, 50, 0.9)',
            backgroundColor: 'rgba(255, 50, 50, 0.5)'
        },       
        '&.normal': {
            borderColor: 'rgba(0, 0, 0, 0.9)',
            backgroundColor: 'rgba(0, 0, 0, 0.5)'
        },
        '&.slidein': { transform: 'translateX(0%)' },
        '&.fade-out': {
            opacity: 0,
            transition: 'opacity 500ms ease-in-out'  
        },
        '& .close-notify': {
            position: 'absolute',
            top: '50%',
            transform: 'translateY(-50%)',
            display: 'inline-block',
            margin: 'auto',
            right: 10,
            fontFamily: 'arial',
            fontSize: 30,
            color: 'red',
            opacity: 0.3,
            cursor: 'pointer',
            textShadow: '1px 0 1px #000, -1px 0 1px #000, 0 -1px 1px #000, 0 1px 1px #000',
            '&:hover': {
                opacity: 0.7
            }
        }
    }
}), { name: 'StyledListItem' });
