import requests
from mounty import Mountebank
from mounty.models import Imposter, Stub, RecordedRequest

# the url must contain the port on which Mountebank is listening
mountebank = Mountebank(url="http://localhost:2525")

# add imposter as dict
imposter = mountebank.add_imposter(imposter={
 "port": 4555,
 "protocol": "http",
 "stubs": [{"responses": [{"is": {"statusCode": 201}}]}],
})


# perform 2 requests
requests.post(url="http://localhost:4556")
requests.post(url="http://localhost:4556")
# wait for maximum 2 seconds for the imposter to contain 2 recorded requests
reqs = mountebank.wait_for_requests(port=4556, count=2, timeout=2)
# validate recorded request
assert type(reqs[0]) == RecordedRequest