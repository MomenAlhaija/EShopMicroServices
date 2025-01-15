﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behavior;

public class LoggingBehaviour<TRequest, TRespons>
    (ILogger<LoggingBehaviour<TRequest,TRespons>> logger) :
    IPipelineBehavior<TRequest, TRespons>
    where TRequest : notnull,IRequest<TRespons>
    where TRespons : notnull

{
    public async Task<TRespons> Handle(TRequest request, RequestHandlerDelegate<TRespons> next, CancellationToken cancellationToken)
    {

        logger.LogInformation("[START] Handle Request={Request} - Response={Response} -RequestData {RequestData}", typeof(TRequest).Name, typeof(TRespons).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();
        
        timer.Stop();
        var timeTaken= timer.Elapsed;
        if (timeTaken.Seconds > 3)
            logger.LogWarning("[PERFORMANCE] The Request={Request} took {TimeTaken}",
                typeof(TRequest).Name, timeTaken.Seconds);

        logger.LogInformation("[END] Handle Request={Request} with {Response}"
            ,typeof(TRequest).Name,typeof(TRespons).Name);

        return response;
    }
}
